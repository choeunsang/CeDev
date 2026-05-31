using CeDev.Models;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace CeDev.Login
{
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.Load += UserInfo_Load;
        }

        private async void UserInfo_Load(object sender, EventArgs e)
        {
            await DoSearch();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await DoSearch();
        }

        private async void btnNew_Click(object sender, EventArgs e)
        {
            await DoNew();
        }

        private async void btnDetail_Click(object sender, EventArgs e)
        {
            await DoDetail();
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            await DoDelete();
        }

        private async Task DoSearch()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string url = "http://localhost:9081/api/user/list";

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("조회 실패");
                        return;
                    }

                    Stopwatch stopwatch = Stopwatch.StartNew();

                    string result = await response.Content.ReadAsStringAsync();
                    List<UserDto> list = JsonConvert.DeserializeObject<List<UserDto>>(result);

                    stopwatch.Stop();

                    if (list == null || list.Count == 0)
                    {
                        lblCnt.Text = "0 건";
                        gvUser.DataSource = null;
                        MessageBox.Show("조회된 데이터가 없습니다.");
                        return;
                    }

                    long elapsedMs = stopwatch.ElapsedMilliseconds;
                    double seconds = elapsedMs / 1000.0; // 초 단위 변환 (0.8초)
   
                    gvUser.DataSource = list;
                    lblCnt.Text = $"{list.Count:N0} 건({seconds:0.0}초)";

                    SetGridHeader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 연결 실패: " + ex.Message);
            }
        }

        private async Task DoNew()
        {
            UserInfoNew form = new UserInfoNew();

            form.ShowDialog();

            await DoSearch();
        }

        private async Task DoDetail()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            int userSeq;
            string userId;
            string userPw;

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            if (gvUser.CurrentRow == null)
            {
                MessageBox.Show("사용자를 선택하세요.");
                return;
            }

            userSeq = Convert.ToInt32(gvUser.CurrentRow.Cells["UserSeq"].Value);
            userId = gvUser.CurrentRow.Cells["UserId"].Value.ToString();
            userPw = gvUser.CurrentRow.Cells["UserPw"].Value.ToString();

            UserInfoDetail detailForm = new UserInfoDetail(userSeq, userId, userPw);
            detailForm.ShowDialog();

            await DoSearch();
        }

        private async Task DoDelete()
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            int userSeq;
            string userId;

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            if (gvUser.CurrentRow == null)
            {
                MessageBox.Show("삭제할 사용자를 선택하세요.");
                return;
            }

            userSeq = Convert.ToInt32(gvUser.CurrentRow.Cells["UserSeq"].Value);
            userId = gvUser.CurrentRow.Cells["UserId"].Value.ToString();

            DialogResult confirmResult = MessageBox.Show(
                $"{userId} 사용자를 삭제하시겠습니까?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            string url = $"http://localhost:9081/api/user/{userSeq}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync(url);
                    string result = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("삭제 실패: " + result);
                        return;
                    }

                    int deleteCnt = Convert.ToInt32(result);

                    if (deleteCnt > 0)
                    {
                        MessageBox.Show("삭제되었습니다.");
                        await DoSearch();
                    }
                    else
                    {
                        MessageBox.Show("삭제 대상이 없습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 연결 실패: " + ex.Message);
            }
        }

        private void SetGridHeader()
        {
            //-------------------------------------------------------------------------------------------
            // 컬럼 한글명
            //-------------------------------------------------------------------------------------------
            gvUser.Columns["UserSeq"].HeaderText = "회원번호";
            gvUser.Columns["UserId"].HeaderText = "아이디";
            gvUser.Columns["UserName"].HeaderText = "회원명";
            gvUser.Columns["RoleCd"].HeaderText = "권한";
            gvUser.Columns["UseYn"].HeaderText = "사용여부";
            gvUser.Columns["RegDate"].HeaderText = "등록일";
            gvUser.Columns["UpdateDate"].HeaderText = "수정일";

            //-------------------------------------------------------------------------------------------
            // 불필요 컬럼 숨김
            //-------------------------------------------------------------------------------------------
            //gvUser.Columns["UserPw"].Visible = false;
            gvUser.Columns["Email"].Visible = false;
            gvUser.Columns["Phone"].Visible = false;
            gvUser.Columns["DeptCd"].Visible = false;

            //-------------------------------------------------------------------------------------------
            // 기타 설정
            //-------------------------------------------------------------------------------------------
            gvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

    }
}
