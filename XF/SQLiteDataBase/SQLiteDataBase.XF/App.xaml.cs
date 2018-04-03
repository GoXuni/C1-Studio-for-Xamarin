using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SQLiteDataBase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            C1.Xamarin.Forms.Core.LicenseManager.Key =
            "ACQBJAIkB31TAFEATABpAHQAZQBEAGEAdABhAEIAYQBzAGUAEwbS5fq37jKvQtBo" +
            "ZionGlpcrBa0/1Rpx9kS33u4sbGRHywvlBF1qAl/16ABJSmwd5zqMw9wX7Bn7PRl" +
            "dl0yiC/VzSaBD0I+b+xp2tOXwULtdHj373QZ4lUqNHQA2RyCwNVLC+A/ffFJLjY7" +
            "LCf+z1jPiS+Q/J/v9zno7bPERjBFddJ8Spp1Vzl64tyv9i+kkXTi7XxHgRR7OZQ4" +
            "p6EEWsb0haCi7Rw2lsbdPrMGhIeB6IeE5UaCgvOvPNcl03nPMtVkKHbg8742LLNK" +
            "CBxMIKGTgjBI1Kwi1F3odZHw/AmcfVoCWVF6NtGrNxDNA3tpGoOMG8wxyflPLQqa" +
            "owe4MhY7bMRf+xzhCEzmH6CcTLSxoFFYWQ8aBPc4eTWjnrzXbrCjbw52x1vJycTA" +
            "MsEamX3SfJNai/uYK+YDgzk142nccuPLQR3vrOe4UVdgF2klylkBn+3pojaE5Rqe" +
            "piFhOEtjrAKSQPistTIBQnQGz4C+GMJx38bEoD9zg96rp8eFivQYxwOHpirN4PQk" +
            "ZU0gZ3jWD8MVNGkj9OHn+KmUJgbW6sC4XREPStif28KYlxjWeSB5dAKOFCI7o6Ub" +
            "bdeJ0+SXn7BuR13SRRJRuPzcwQc77QuD+FS23/arcLAc1ZJM2G0J1OqgyO4JkbgN" +
            "5MKHLlsQCacQrskekbElRHdfgvQwggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9" +
            "EJSLMA0GCSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVy" +
            "aVNpZ24sIEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5" +
            "BgNVBAsTMlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20v" +
            "cnBhIChjKTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmlu" +
            "ZyAyMDEwIENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1MTIyMjIzNTk1OVowgYYxCzAJ" +
            "BgNVBAYTAkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAWBgNVBAcTD1NlbmRhaSBJenVt" +
            "aS1rdTEXMBUGA1UEChQOR3JhcGVDaXR5IGluYy4xGjAYBgNVBAsUEVRvb2xzIERl" +
            "dmVsb3BtZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkgaW5jLjCCASIwDQYJKoZIhvcN" +
            "AQEBBQADggEPADCCAQoCggEBAMEC9splW7KVpAqRB6VVB7XJm8+a60x78HZWNmvA" +
            "js/ermp7pbh8M9HYuEVTRj8H4baXxFYq4i75e5kNr7s+nGbJ5UfM6CldqbeRsQ4z" +
            "vRb6npfrtcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6qdHZLf/EcvSIKvRbu3ILOE3k" +
            "uux07gQkb++rrSBUyJKXU8nW8c+K+9sfWqHYPb8FF2IazWxhmfIdIoDNKyjr3r/w" +
            "In3jQejpqfamiHNsU/O26KS0EcvCS5CFOKDT6vvdnAkek3kyLWef+ca/cbFo74va" +
            "wYGtmw2wzw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+C8E4T+8CAwEAAaOCAY0wggGJ" +
            "MAkGA1UdEwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsGA1UdHwQkMCIwIKAeoByGGmh0" +
            "dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3JsMGYGA1UdIARfMF0wWwYLYIZIAYb4RQEH" +
            "FwMwTDAjBggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5bWNiLmNvbS9jcHMwJQYIKwYB" +
            "BQUHAgIwGQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9ycGEwEwYDVR0lBAwwCgYIKwYB" +
            "BQUHAwMwVwYIKwYBBQUHAQEESzBJMB8GCCsGAQUFBzABhhNodHRwOi8vc2Yuc3lt" +
            "Y2QuY29tMCYGCCsGAQUFBzAChhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNydDAf" +
            "BgNVHSMEGDAWgBTPmanqeyb0S8mOj9fwBSbv49KnnTAdBgNVHQ4EFgQUAFrwraXU" +
            "eDX1hBKoLAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisGAQQBgjcCARsE" +
            "CDAGAQEAAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCIwphaN45b5ViKsRfCA6hbVeqM" +
            "hNCJmL64mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lpcr9PjfGJ55ZX4sZlqoxeflTp" +
            "HgnX8MPJuKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0gjHIAQ2ZEf2PJ6TTSFcvj24w" +
            "h73dsyqcmj290fpwDtHaF2jE5pq/tQBOJ8vDkN46wt4qMhG6nIpOgc9KngyLLdEO" +
            "7V34KM1Nb+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3kIGK+f1kP1xqTBpXwsBE5sLl" +
            "nujP+JAqV8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5QE5jAvPQeXevLnMYiqJrgMIIC" +
            "xjCCAa6gAwIBAgIEDu7u7jANBgkqhkiG9w0BAQUFADAlMSMwIQYDVQQDDBpHQy1Y" +
            "dW5pIEludGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDEwODM2NTJaFw0zNzEyMzEw" +
            "ODM2NTJaMCUxIzAhBgNVBAMMGkdDLVh1bmkgSW50ZXJuYWwgRGV2ZWxvcGVyMIIB" +
            "IjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA15V9OD1KDGsnjO9KTcFLgmYm" +
            "O8wy1EqzmtA5IVbaueeokerMOVp6P98Zdlc2S4T+45lG5ACapZDMePn017neh+kX" +
            "uBUQZnBmA8BnPQ1Yag4JPjJKZi0GKhOwlr8CB8AfO2z7e/SdZD+1yi20mBUKwKI7" +
            "UKBBpg0esNytPW69/2IfsTyOxaP42BQTIOtuXAFzjwmRiv0caXW2fFTlK/04Issi" +
            "PVJ1kZ/OcPZtEBO3Op+dpx3qnQq7o66O0UvvGK2mJ2IU+O3ejR+7k+sSh2qhyRi3" +
            "u//SVCfI/vmIcJ54VFWhosM3UtEIfI7T4FHAH5rox/H7txpqa0qwtBhkSVIbHwID" +
            "AQABMA0GCSqGSIb3DQEBBQUAA4IBAQCOSTI0KFxRTEfJUne0kmgfs0b04JBdMYEO" +
            "C61Y3Qb07z89rcP4uD4Qi+NgT2vaV91C/5vRRDs//+oySZxJ8sGprMYmwnqjf654" +
            "g9ait6FfFvMEQC3FyyNTAF9MgLUTdeMfF4Jh4xIkWQPmpWCr4BiGCnAdI+fAr6tZ" +
            "OVhfY1U9acqB4zPdoz/CmzyfWb4qfsJB2dUwNlYW8g1unnkSJ/a9BeTryg4Cq8oT" +
            "GYbYF2TGWD4zlzkwqpShu26qZMkk6+Z/KexDkW/464yg4zIx20kVsFP09oSVe5N4" +
            "Aju3vgsVHdR8FM9a9+PrFMWEARkwMR1hy8VlU6zfhczX85J6mCxf";
            MainPage = new NavigationPage(new SQLiteDataBase.MainPage()) { BarBackgroundColor = Color.FromHex("#9E9E9E"), BarTextColor = Color.White };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
