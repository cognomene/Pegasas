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
            firstLevelMenuPage.NavigateToPage();
            firstLevelMenuPage.CloseCookies();

            firstLevelMenuPage.Click_NaujosKnygos();
            firstLevelMenuPage.Verify_NaujosKnygos_Link("https://www.pegasas.lt/knygos/naujos-knygos/");

            firstLevelMenuPage.Click_NetrukusPasirodys();
            firstLevelMenuPage.Verify_NetrukusPasirodys_Link("https://www.pegasas.lt/knygos/naujos-knygos/netrukus-pasirodys/");

            firstLevelMenuPage.Click_TopKnygos();
            firstLevelMenuPage.Verify_TopKnygos_Link("https://www.pegasas.lt/c/perkamiausios-knygos");

            firstLevelMenuPage.Click_PegasoKolekcija();
            firstLevelMenuPage.Verify_PegasoKolekcija_Link("https://www.pegasas.lt/pegaso-kolekcijos-knygos/");

            firstLevelMenuPage.Click_KakeMake();
            firstLevelMenuPage.Verify_KakeMake_Link("https://www.pegasas.lt/c/kakes-makes-pasaulis/");

            firstLevelMenuPage.Click_DovanuKuponai();
            firstLevelMenuPage.Verify_DovanuKuponai_Link("https://www.pegasas.lt/el-dovanu-kuponas-21000895/");

            firstLevelMenuPage.Click_Superkainos();
            firstLevelMenuPage.Verify_Superkainos_Link("https://www.pegasas.lt/akcijos/rudens-super-kainos/");
        }
    }
}