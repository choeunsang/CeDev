using CeDev.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using System.Net.Http;


namespace CeDev.DataMng
{
    public partial class DataUpdate : Form
    {
        private bool _workYn = false;

        public DataUpdate()
        {
            InitializeComponent();
        }

        private async void btnRealInfoUpdate_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables 
            //-------------------------------------------------------------------------------------------
            if (_workYn)
            {
                MessageBox.Show("지금 작업중 입니다.");
                return;
            }

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            try
            {
                _workYn = true;

                btnRealInfoUpdate.Enabled = false;

                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;

                await UpdateRealEstateData();

                MessageBox.Show("전체 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _workYn = false;

                btnRealInfoUpdate.Enabled = true;

                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Value = 0;
            }
        }

        private async void btnRentInfoUpdate_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables 
            //-------------------------------------------------------------------------------------------
            if (_workYn)
            {
                MessageBox.Show("지금 작업중 입니다.");
                return;
            }

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------
            try
            {
                _workYn = true;

                btnRealInfoUpdate.Enabled = false;

                progressBar2.Style = ProgressBarStyle.Marquee;
                progressBar2.MarqueeAnimationSpeed = 30;

                await UpdateRealEstateData_Rent();

                MessageBox.Show("전체 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _workYn = false;

                btnRentInfoUpdate.Enabled = true;

                progressBar2.Style = ProgressBarStyle.Blocks;
                progressBar2.MarqueeAnimationSpeed = 0;
                progressBar2.Value = 0;
            }
        }


        private async Task UpdateRealEstateData()
        {
            //-------------------------------------------------------------------------------------------------------------------------------
            //Declare and initialize variables
            //-------------------------------------------------------------------------------------------------------------------------------
            //string priceDt01 = "202601";
            //string priceDt02 = "202602";
            //string priceDt03 = "202603";
            //string priceDt04 = "202604";
            //string priceDt05 = "202605";
            string priceDt06 = "202606";
            //string priceDt07 = "202607";
            //string priceDt08 = "202608";
            //string priceDt09 = "202609";
            //string priceDt10 = "202610";
            //string priceDt11 = "202611";
            //string priceDt12 = "202612";

            string tableNm01 = "KR_REAL_INFO";

            //var path01 = @"C:\tempReal\" + priceDt01 + ".csv";
            //var path02 = @"C:\tempReal\" + priceDt02 + ".csv";
            //var path03 = @"C:\tempReal\" + priceDt03 + ".csv";
            //var path04 = @"C:\tempReal\" + priceDt04 + ".csv";
            //var path05 = @"C:\tempReal\" + priceDt05 + ".csv";
            var path06 = @"C:\tempReal\" + priceDt06 + ".csv";
            //var path07 = @"C:\tempReal\" + priceDt07 + ".csv";
            //var path08 = @"C:\tempReal\" + priceDt08 + ".csv";
            //var path09 = @"C:\tempReal\" + priceDt09 + ".csv";
            //var path10 = @"C:\tempReal\" + priceDt10 + ".csv";
            //var path11 = @"C:\tempReal\" + priceDt11 + ".csv";
            //var path12 = @"C:\tempReal\" + priceDt12 + ".csv";


            //var csv01 = new List<string[]>(); // or, List<YourClass>
            //var csv02 = new List<string[]>(); // or, List<YourClass>
            //var csv03 = new List<string[]>(); // or, List<YourClass>
            //var csv04 = new List<string[]>(); // or, List<YourClass>
            //var csv05 = new List<string[]>(); // or, List<YourClass>
            var csv06 = new List<string[]>(); // or, List<YourClass>
            //var csv07 = new List<string[]>(); // or, List<YourClass>
            //var csv08 = new List<string[]>(); // or, List<YourClass>
            //var csv09 = new List<string[]>(); // or, List<YourClass>
            //var csv10 = new List<string[]>(); // or, List<YourClass>
            //var csv11 = new List<string[]>(); // or, List<YourClass>
            //var csv12 = new List<string[]>(); // or, List<YourClass>

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //var lines01 = System.IO.File.ReadAllLines(path01, Encoding.GetEncoding(949));
            //var lines02 = System.IO.File.ReadAllLines(path02, Encoding.GetEncoding(949));
            //var lines03 = System.IO.File.ReadAllLines(path03, Encoding.GetEncoding(949));
            //var lines04 = System.IO.File.ReadAllLines(path04, Encoding.GetEncoding(949));
            //var lines05 = System.IO.File.ReadAllLines(path05, Encoding.GetEncoding(949));
            var lines06 = System.IO.File.ReadAllLines(path06, Encoding.GetEncoding(949));
            //var lines07 = System.IO.File.ReadAllLines(path07, Encoding.GetEncoding(949));
            //var lines08 = System.IO.File.ReadAllLines(path08, Encoding.GetEncoding(949));
            //var lines09 = System.IO.File.ReadAllLines(path09, Encoding.GetEncoding(949));
            //var lines10 = System.IO.File.ReadAllLines(path10, Encoding.GetEncoding(949));
            //var lines11 = System.IO.File.ReadAllLines(path11, Encoding.GetEncoding(949));
            //var lines12 = System.IO.File.ReadAllLines(path12, Encoding.GetEncoding(949));

            //-------------------------------------------------------------------------------------------------------------------------------
            //Processing
            //-------------------------------------------------------------------------------------------------------------------------------
            int rowNum = 0;
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            //foreach (string line in lines01)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv01.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines02)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv02.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines03)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv03.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines04)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv04.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines05)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv05.Add(Fields);
            //    }
            //    rowNum++;
            //}

            rowNum = 0;
            foreach (string line in lines06)
            {
                if (rowNum > 16)
                {
                    String[] Fields = CSVParser.Split(line);
                    csv06.Add(Fields);
                }
                rowNum++;
            }

            //rowNum = 0;
            //foreach (string line in lines07)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv07.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines08)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv08.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines09)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv09.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines10)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv10.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines11)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv11.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines12)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv12.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //-------------------------------------------------------------------------------------------------------------------------------
            //Output
            //-------------------------------------------------------------------------------------------------------------------------------
            //await CreateRealEstateDataByCsv(csv01, priceDt01, tableNm01);
            //await CreateRealEstateDataByCsv(csv02, priceDt02, tableNm01);
            //await CreateRealEstateDataByCsv(csv03, priceDt03, tableNm01);
            //await CreateRealEstateDataByCsv(csv04, priceDt04, tableNm01);
            //await CreateRealEstateDataByCsv(csv05, priceDt05, tableNm01);

            await CreateRealEstateDataByCsv(csv06, priceDt06, tableNm01);


        }

        public async Task CreateRealEstateDataByCsv(List<string[]> pCsv, string pPriceDt, string pTableNm)
        {
            List<EstateItem> list = new List<EstateItem>();

            //int rowNum = 0;

            foreach (var row in pCsv)
            {
                if (row.Length == 15)
                {
                    EstateItem item = new EstateItem();

                    item.City = row[0];
                    item.Bungi = row[1];
                    item.BonBun = row[2];
                    item.BuBun = row[3];
                    item.Dangi = row[4];
                    item.DediArea = row[5];
                    item.ContYear = row[6];
                    item.ContDate = row[7];

                    item.Amount = row[8];
                    item.Floor = row[9];
                    item.ConsYear = row[10];
                    item.Road = row[11];
                    item.DateCancel = row[12];
                    item.TransType = row[13];
                    item.BrokerLoc = row[14];

                    SetRegionInfo(item);
                    list.Add(item);
                }
                else if (row.Length == 16)
                {
                    EstateItem item = new EstateItem();

                    item.City = row[0];
                    item.Bungi = row[1];
                    item.BonBun = row[2];
                    item.BuBun = row[3];
                    item.Dangi = row[4];
                    item.DediArea = row[5];
                    item.ContYear = row[6];
                    item.ContDate = row[7];

                    item.Amount = row[8];
                    item.Floor = row[9];
                    item.ConsYear = row[10];
                    item.Road = row[11];
                    item.DateCancel = row[12];
                    item.RegiDt = row[13];        //등기일자
                    item.TransType = row[14];
                    item.BrokerLoc = row[15];

                    SetRegionInfo(item);
                    list.Add(item);
                }
                else if (row.Length == 20)
                {
                    EstateItem item = new EstateItem();

                    item.City = row[1];
                    item.Bungi = row[2];
                    item.BonBun = row[3];
                    item.BuBun = row[4];
                    item.Dangi = row[5];
                    item.DediArea = row[6];
                    item.ContYear = row[7];
                    item.ContDate = row[8];

                    item.Amount = row[9];
                    item.Floor = row[11];
                    item.ConsYear = row[14];
                    item.Road = row[15];
                    item.DateCancel = row[16];
                    item.TransType = row[17];
                    item.BrokerLoc = row[18];
                    item.RegiDt = row[19];        //등기일자

                    SetRegionInfo(item);
                    list.Add(item);
                }

                //rowNum++;
            }

            await InsertEstateDataToDB(list, pTableNm, pPriceDt);
        }

        private async Task InsertEstateDataToDB(List<EstateItem> list, string pTableNm, string pPriceDt)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string url =
                "http://localhost:9081/api/data/estate/insert-housTrad" +
                $"?tableNm={pTableNm}" +
                $"&dt={pPriceDt}";

            string json = JsonConvert.SerializeObject(
                list,
                new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                }
            );

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------^
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response =
                    await client.PostAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();

                //MessageBox.Show(result);
            }
        }


        private async Task UpdateRealEstateData_Rent()
        {
            //-------------------------------------------------------------------------------------------------------------------------------
            //Declare and initialize variables
            //-------------------------------------------------------------------------------------------------------------------------------
            //string priceDt01 = "R_202501";
            //string priceDt02 = "R_202502";
            //string priceDt03 = "R_202503";
            //string priceDt04 = "R_202504";
            //string priceDt05 = "R_202505";
            //string priceDt06 = "R_202506";
            //string priceDt07 = "R_202507";
            //string priceDt08 = "R_202508";
            //string priceDt09 = "R_202509";
            //string priceDt10 = "R_202510";
            //string priceDt11 = "R_202511";
            //string priceDt12 = "R_202512";

            string priceDt01 = "R_202601";
            string priceDt02 = "R_202602";
            string priceDt03 = "R_202603";
            string priceDt04 = "R_202604";
            string priceDt05 = "R_202605";
            string priceDt06 = "R_202606";
            //string priceDt07 = "R_202607";
            //string priceDt08 = "R_202608";
            //string priceDt09 = "R_202609";
            //string priceDt10 = "R_202610";
            //string priceDt11 = "R_202611";
            //string priceDt12 = "R_202612";

            string tableNm01 = "KR_REAL_RENT_INFO";

            var path01 = @"C:\tempReal\" + priceDt01 + ".csv";
            var path02 = @"C:\tempReal\" + priceDt02 + ".csv";
            var path03 = @"C:\tempReal\" + priceDt03 + ".csv";
            var path04 = @"C:\tempReal\" + priceDt04 + ".csv";
            var path05 = @"C:\tempReal\" + priceDt05 + ".csv";
            var path06 = @"C:\tempReal\" + priceDt06 + ".csv";
            //var path07 = @"C:\tempReal\" + priceDt07 + ".csv";
            //var path08 = @"C:\tempReal\" + priceDt08 + ".csv";
            //var path09 = @"C:\tempReal\" + priceDt09 + ".csv";
            //var path10 = @"C:\tempReal\" + priceDt10 + ".csv";
            //var path11 = @"C:\tempReal\" + priceDt11 + ".csv";
            //var path12 = @"C:\tempReal\" + priceDt12 + ".csv";


            var csv01 = new List<string[]>(); // or, List<YourClass>
            var csv02 = new List<string[]>(); // or, List<YourClass>
            var csv03 = new List<string[]>(); // or, List<YourClass>
            var csv04 = new List<string[]>(); // or, List<YourClass>
            var csv05 = new List<string[]>(); // or, List<YourClass>
            var csv06 = new List<string[]>(); // or, List<YourClass>
            //var csv07 = new List<string[]>(); // or, List<YourClass>
            //var csv08 = new List<string[]>(); // or, List<YourClass>
            //var csv09 = new List<string[]>(); // or, List<YourClass>
            //var csv10 = new List<string[]>(); // or, List<YourClass>
            //var csv11 = new List<string[]>(); // or, List<YourClass>
            //var csv12 = new List<string[]>(); // or, List<YourClass>

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var lines01 = System.IO.File.ReadAllLines(path01, Encoding.GetEncoding(949));
            var lines02 = System.IO.File.ReadAllLines(path02, Encoding.GetEncoding(949));
            var lines03 = System.IO.File.ReadAllLines(path03, Encoding.GetEncoding(949));
            var lines04 = System.IO.File.ReadAllLines(path04, Encoding.GetEncoding(949));
            var lines05 = System.IO.File.ReadAllLines(path05, Encoding.GetEncoding(949));
            var lines06 = System.IO.File.ReadAllLines(path06, Encoding.GetEncoding(949));
            //var lines07 = System.IO.File.ReadAllLines(path07, Encoding.GetEncoding(949));
            //var lines08 = System.IO.File.ReadAllLines(path08, Encoding.GetEncoding(949));
            //var lines09 = System.IO.File.ReadAllLines(path09, Encoding.GetEncoding(949));
            //var lines10 = System.IO.File.ReadAllLines(path10, Encoding.GetEncoding(949));
            //var lines11 = System.IO.File.ReadAllLines(path11, Encoding.GetEncoding(949));
            //var lines12 = System.IO.File.ReadAllLines(path12, Encoding.GetEncoding(949));

            //-------------------------------------------------------------------------------------------------------------------------------
            //Processing
            //-------------------------------------------------------------------------------------------------------------------------------
            int rowNum = 0;
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            foreach (string line in lines01)
            {
                if (rowNum > 18)
                {
                    String[] Fields = CSVParser.Split(line);
                    csv01.Add(Fields);
                }
                rowNum++;
            }

            rowNum = 0;
            foreach (string line in lines02)
            {
                if (rowNum > 16)
                {
                    String[] Fields = CSVParser.Split(line);
                    csv02.Add(Fields);
                }
                rowNum++;
            }

            rowNum = 0;
            foreach (string line in lines03)
            {
                if (rowNum > 16)
                {
                    String[] Fields = CSVParser.Split(line);
                    csv03.Add(Fields);
                }
                rowNum++;
            }

            rowNum = 0;
            foreach (string line in lines04)
            {
                if (rowNum > 16)
                {
                    String[] Fields = CSVParser.Split(line);
                    csv04.Add(Fields);
                }
                rowNum++;
            }

            rowNum = 0;
            foreach (string line in lines05)
            {
                if (rowNum > 16)
                {
                    String[] Fields = CSVParser.Split(line);
                    csv05.Add(Fields);
                }
                rowNum++;
            }

            rowNum = 0;
            foreach (string line in lines06)
            {
                if (rowNum > 16)
                {
                    String[] Fields = CSVParser.Split(line);
                    csv06.Add(Fields);
                }
                rowNum++;
            }

            //rowNum = 0;
            //foreach (string line in lines07)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv07.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines08)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv08.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines09)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv09.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines10)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv10.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines11)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv11.Add(Fields);
            //    }
            //    rowNum++;
            //}

            //rowNum = 0;
            //foreach (string line in lines12)
            //{
            //    if (rowNum > 16)
            //    {
            //        String[] Fields = CSVParser.Split(line);
            //        csv12.Add(Fields);
            //    }
            //    rowNum++;
            //}


            //-------------------------------------------------------------------------------------------------------------------------------
            //Output
            //-------------------------------------------------------------------------------------------------------------------------------
            await CreateRealEstateRentDataByCsv(csv01, priceDt01, tableNm01);
            await CreateRealEstateRentDataByCsv(csv02, priceDt02, tableNm01);
            await CreateRealEstateRentDataByCsv(csv03, priceDt03, tableNm01);
            await CreateRealEstateRentDataByCsv(csv04, priceDt04, tableNm01);
            await CreateRealEstateRentDataByCsv(csv05, priceDt05, tableNm01);

            await CreateRealEstateRentDataByCsv(csv06, priceDt06, tableNm01);
        }

        public async Task CreateRealEstateRentDataByCsv(List<string[]> pCsv, string pPriceDt, string pTableNm)
        {
            List<EstateRentItem> list = new List<EstateRentItem>();

            //int rowNum = 0;

            foreach (var row in pCsv)
            {
                if (row.Length == 19)
                {
                    EstateRentItem item = new EstateRentItem();

                    item.City = row[0];
                    item.Bungi = row[1];
                    item.BonBun = row[2];
                    item.BuBun = row[3];
                    item.Dangi = row[4];

                    item.Gubun = row[5];

                    item.DediArea = row[6];
                    item.ContYear = row[7];
                    item.ContDate = row[8];

                    item.Deposit = row[9];
                    item.MonPay = row[10];

                    item.Floor = row[11];
                    item.ConsYear = row[12];
                    item.Road = row[13];

                    item.Term = row[14];
                    item.TermGubun = row[15];
                    item.RightRequ = row[16];

                    item.PrevDeposit = row[17];
                    item.PrevMonPay = row[18];

                    SetRegionInfo(item);
                    list.Add(item);
                }
                else if (row.Length == 21)
                {
                    EstateRentItem item = new EstateRentItem();

                    item.City = row[1];
                    item.Bungi = row[2];
                    item.BonBun = row[3];
                    item.BuBun = row[4];
                    item.Dangi = row[5];

                    item.Gubun = row[6];

                    item.DediArea = row[7];
                    item.ContYear = row[8];
                    item.ContDate = row[9];

                    item.Deposit = row[10];
                    item.MonPay = row[11];

                    item.Floor = row[12];
                    item.ConsYear = row[13];
                    item.Road = row[14];

                    item.Term = row[15];
                    item.TermGubun = row[16];
                    item.RightRequ = row[17];

                    item.PrevDeposit = row[18];
                    item.PrevMonPay = row[19];

                    item.HouseKind = row[20];

                    SetRegionInfo(item);
                    list.Add(item);
                }       
            }

            pPriceDt = pPriceDt.Replace("R_", "");
            await InsertEstateRentDataToDB(list, pTableNm, pPriceDt);
        }

        private async Task InsertEstateRentDataToDB(List<EstateRentItem> list, string pTableNm, string pPriceDt)
        {
            //-------------------------------------------------------------------------------------------
            // Declare and initialize variables
            //-------------------------------------------------------------------------------------------
            string url =
                "http://localhost:9081/api/data/estate/insert-housRent" +
                $"?tableNm={pTableNm}" +
                $"&dt={pPriceDt}";

            string json = JsonConvert.SerializeObject(
                list,
                new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                }
            );

            //-------------------------------------------------------------------------------------------
            // Processing
            //-------------------------------------------------------------------------------------------^
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response =
                    await client.PostAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();

                //MessageBox.Show(result);
            }
        }


        private void SetRegionInfo(EstateItem item)
        {
            if (string.IsNullOrWhiteSpace(item.City))
            {
                return;
            }

            string city = item.City.Replace("\"", "").Trim();
            string[] parts = city.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 1)
            {
                item.Sido = parts[0];
            }

            if (parts.Length >= 2)
            {
                item.Sigungu = parts[1];
            }

            if (parts.Length >= 3)
            {
                item.Dong = parts[2];
            }
        }

        private void SetRegionInfo(EstateRentItem item)
        {
            if (string.IsNullOrWhiteSpace(item.City))
            {
                return;
            }

            string city = item.City.Replace("\"", "").Trim();
            string[] parts = city.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 1)
            {
                item.Sido = parts[0];
            }

            if (parts.Length >= 2)
            {
                item.Sigungu = parts[1];
            }

            if (parts.Length >= 3)
            {
                item.Dong = parts[2];
            }
        }
    }
}
