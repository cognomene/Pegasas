using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BaigiamasisDarbas.Page;

namespace BaigiamasisDarbas.Test
{
    public class FirstLevelMenuTest : BaseTest
    {
        [Test]
        public static void Click_First_Level_Menu_Links()
        {
            FirstLevelMenuPage page = new FirstLevelMenuPage(chromeDriver);
            page.NavigateToPage();
            page.CloseCookies();

            page.Click_NaujosKnygos();
            page.Verify_NaujosKnygos_Link("https://www.pegasas.lt/knygos/naujos-knygos/");

            page.Click_NetrukusPasirodys();
            page.Verify_NetrukusPasirodys_Link("https://www.pegasas.lt/knygos/naujos-knygos/netrukus-pasirodys/");

            page.Click_TopKnygos();
            page.Verify_TopKnygos_Link("https://www.pegasas.lt/c/perkamiausios-knygos");

            page.Click_PegasoKolekcija();
            page.Verify_PegasoKolekcija_Link("https://www.pegasas.lt/pegaso-kolekcijos-knygos/");

            page.Click_KakeMake();
            page.Verify_KakeMake_Link("https://www.pegasas.lt/c/kakes-makes-pasaulis/");

            page.Click_DovanuKuponai();
            page.Verify_DovanuKuponai_Link("https://www.pegasas.lt/el-dovanu-kuponas-21000895/");

            page.Click_Superkainos();
            page.Verify_Superkainos_Link("https://www.pegasas.lt/akcijos/rudens-super-kainos/");
        }

    }
}