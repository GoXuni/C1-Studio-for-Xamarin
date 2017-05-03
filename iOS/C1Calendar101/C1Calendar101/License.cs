using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace C1Calendar101
{
    public static class License
    {
        public const string Key =
            "ACIBIgIiB4pDADEAQwBhAGwAZQBuAGQAYQByADEAMAAxAKuLt+N9loL6XqAJxkOT" +
            "Yp48x3s97IiKykbR875gUkIvjjETNAIjBpAMNaxydTs/KM2iPQ1UBmsPVpiEuRTA" +
            "27L2LwzfTdushgiyfBDxzH2S8lWIdWuU5l+cdqbBR6LIXBoThD+0mYNGTA7N3ZHH" +
            "FIOjrP7rTrUIDSkSnAun6/tHhNEazNs4cnFPxkYljqIalT6uZfUoxhWzqHMHkD3R" +
            "XwJc7yueb0D14JU7RhWgUaaxo6a05ugrlsnCH382XWtHRr2USrli8MEd0V7ZilPP" +
            "OgO+/lpTInUcEDBGqOhoXN5JHIKgrB1sPM7aqlaGukr9vaFiWgYVKh7UIdspPDT/" +
            "pLJYoUIBWIhr3BqhWmFsVyee1rBk/2a5hLlqJRGiNV+KSmFhed6fsf60wyS70UVY" +
            "BdmIjsd6Th4RjLJt2/qgSy+/uqBcH9wMycZEwEvf+M1f3Xwn+MMkCdxRoAAbquFg" +
            "MBfMZIb9KneSfmu89mBplONC/k3TMW/YEG2jeetir4GsfOEaewo0sLqXSsB9na6Y" +
            "b9Te290R0r6Dpgkw9+1KWhm2Rz9tIIorAjwE7++Tbo0/IVj2wOestlzO77HGZ8Nb" +
            "pWikrL2MgEJHb8sNm/CUUH6qvNNcnHJSuy14nb02QlB0oh5apHNo7m1Ow3Wzr0/v" +
            "s8r6Jbx91Xh+T7H+upQlCUqgMIIFZDCCBEygAwIBAgIQIhCyF0sLEn+7KAUuEbMl" +
            "CjANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlT" +
            "aWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYD" +
            "VQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3Jw" +
            "YSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcg" +
            "MjAxMCBDQTAeFw0xMzA5MjQwMDAwMDBaFw0xNjEwMjMyMzU5NTlaMIGnMQswCQYD" +
            "VQQGEwJVUzEVMBMGA1UECBMMUGVubnN5bHZhbmlhMRMwEQYDVQQHEwpQaXR0c2J1" +
            "cmdoMRUwEwYDVQQKFAxDb21wb25lbnRPbmUxPjA8BgNVBAsTNURpZ2l0YWwgSUQg" +
            "Q2xhc3MgMyAtIE1pY3Jvc29mdCBTb2Z0d2FyZSBWYWxpZGF0aW9uIHYyMRUwEwYD" +
            "VQQDFAxDb21wb25lbnRPbmUwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIB" +
            "AQC5y6CaqUlVapyS82tOZUyHGpHL8pe3cQcWfnMJOAqpOvlGgun+WeS70Q9fgIYg" +
            "EbpSICO7z4JAn/nPN4jlYkFsiblxSTJxmr2twGel/6NA2lKs2MxTls/zKwMzib2D" +
            "La4/zU/ZvAVnovlJGNTVlMrYkmtCSDWLeeYvxc7cV7T+ytuy492WMMFJDSziieH/" +
            "qpEdEEp8oGFEEMjAzi4Ob32JAy3VEJDa3rQU9iWesenZDXAqYn+XW2dNTDhRBI2S" +
            "ZRnZ763p7jmH8OQjZaA0gkc7bUifPSbSTo0McqwUH9cpTl6Ilwj6cwFwlNkhf3WF" +
            "0oplTPKU9DWe6VDRtR/gM9pzAgMBAAGjggF7MIIBdzAJBgNVHRMEAjAAMA4GA1Ud" +
            "DwEB/wQEAwIHgDBABgNVHR8EOTA3MDWgM6Axhi9odHRwOi8vY3NjMy0yMDEwLWNy" +
            "bC52ZXJpc2lnbi5jb20vQ1NDMy0yMDEwLmNybDBEBgNVHSAEPTA7MDkGC2CGSAGG" +
            "+EUBBxcDMCowKAYIKwYBBQUHAgEWHGh0dHBzOi8vd3d3LnZlcmlzaWduLmNvbS9y" +
            "cGEwEwYDVR0lBAwwCgYIKwYBBQUHAwMwcQYIKwYBBQUHAQEEZTBjMCQGCCsGAQUF" +
            "BzABhhhodHRwOi8vb2NzcC52ZXJpc2lnbi5jb20wOwYIKwYBBQUHMAKGL2h0dHA6" +
            "Ly9jc2MzLTIwMTAtYWlhLnZlcmlzaWduLmNvbS9DU0MzLTIwMTAuY2VyMB8GA1Ud" +
            "IwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j0qedMBEGCWCGSAGG+EIBAQQEAwIEEDAW" +
            "BgorBgEEAYI3AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAYc1WOc48" +
            "GABY5iGtiUlm6nl0NY639qOQ6EWFoCP/uCxKSflNqPlQCOZCGEjRqeWI6u170KLI" +
            "7PwuqncKX03d24dpRBEeFwkc6aPuByvVscI9A/D9VKFJ+Ny45WzAfxs0UYTatATf" +
            "hE5Q9PgXo7KaFLLHeRkYRizTl5rQ1fvf2u4+4fbeSRDJPviW5crFXulKXILaGPV4" +
            "LmS7JuQzoUE9ECJYDiCtUEpf8IYihnTwXw+YzeP0h7BlVGz6Qvj8Y4eck/y0pvfj" +
            "apPrczEEHKW033iyrPZC4LBuFKPX7IOcDpeBTeAgR6Ngi1xKra4st//66VDDrrVS" +
            "pptWsB4YBqrLhTCCArgwggGgoAMCAQICCEbJX84xs7U/MA0GCSqGSIb3DQEBBQUA" +
            "MBwxGjAYBgNVBAMMEUdDLVNVMTE3MDAtNjU0MTUxMB4XDTE3MDEwMTAwMDAwMFoX" +
            "DTE4MDQzMDAwMDAwMFowHDEaMBgGA1UEAwwRR0MtU1UxMTcwMC02NTQxNTEwggEi" +
            "MA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQC/iwymQykWNe4RLC2IG2vYFxWn" +
            "k2B7wxA0MVZI1GNLSY5BCZqisbvJ87g17TbRqzJ9exDFdKc48XPfMUyzGdhE6Qxv" +
            "jonJpkxJk7lQakT0e2MWWu3Ada08wjrjGIW5DZ069Myfc0f1CK8/sm/i0GaaMmXv" +
            "MNRAxs9wwJ7tIypHNqOW7VIYGQdcKx8G/9e1jCwAlvuK+jVDiLn41vh65gkedCAc" +
            "JRAAhZ5DVpc2dhAKpvxgoALbnXacSKWHLKBm0HXLatlvhhnj2fBRqKftIB12uB25" +
            "USer9QE+RYmM8PdRVsECdi1ql+ahshY/cMyFWKdsghw+LNY6Qrhj/hjmodyRAgMB" +
            "AAEwDQYJKoZIhvcNAQEFBQADggEBAFD94MAG1var+++zxOKOVH5u3EBt8AeW6jtU" +
            "eYMks1wYeFfNTI/diXtxnniGRSAdWCUhJkfIfAv8WqomziYE6vxlOknZSTmudhW8" +
            "JUmqfIvVGYMGcf+WsQH00YTW4hV09Ubuy0b82v/w01BNmBZtXyhdMXl5yiGIRUoN" +
            "Jfs7LI6S6vd4Ui9UT3rA7sDDqGV07FJjAkHYwNvCrZ3lEsSIrodFP1PvxYnclYu2" +
            "9pFiV+/esXecWMtoIySizuIssnZnVxJ5vIiLWc/CkXi2pJ3HYfKKdTV5JezHzBGG" +
            "NZihBUoBVCXmv92nAZ3253OjK+Wvfvm0o+avsBsJz3+FFlMl9Fw=";
    }

}