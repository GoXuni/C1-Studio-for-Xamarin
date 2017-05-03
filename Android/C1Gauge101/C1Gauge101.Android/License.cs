using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace C1Gauge101
{
    public static class License
    {
        public const string Key =
            "ABwBHAIcB4RDADEARwBhAHUAZwBlADEAMAAxAIisMuaeWXmArItb2ncG3W+WKfCc" +
            "X+hNF4Q3AVf+Cd8ynDxfNAFA+kMozqzyq9dHSmS9n5v2KSd9TEHoOankw2BarEMp" +
            "ZMXv82dqsfop2JNtJih3ZfkxioOgcAICpdHSbvcLurj2eucDoP85FUol+lHGdfcG" +
            "pG1iAapmiQ0YhWOnbEizgSYU96w6dzYAfIWlSGGqWNmxLCFWbmae4cMPB744CJSs" +
            "z8Rq+lRfkvmJCc+lHgwFOksSQVf5K7X9WoJYOHdLTotJ5pnBZi4YM5O9yga/tTLE" +
            "Db04EsI0IBt9SEZBk5REbRUvvzTWnULcjXS4Pqv08TOs2Amd9qHXNDHzMwNOj+km" +
            "rSgGnS3vvyuYX8z4Qpf+K9AaZECQYIgRldyLmwFbdvCwA3x11GnMoazh6ph+26Jm" +
            "QyCvljcDfGM2X07daHkDiAbzQh/+giQ4yjNAcUSS2eIx7yIquvNOOYVz3z7/TRd3" +
            "YnAQiTVPPWFU2uPojSoZWbpAmrSG75cJtxAIQzJRLoC7CgNOoqmz1rZrRV3zxpXE" +
            "V+1Vb+CbIQiTK67C0yOabAiDeCiYH9EnuwQsJqV3Mwknt3c9TwpJWVIUQy/TJt8h" +
            "4iyzi/UBuNqFM1ztuyaz+EUhyO12rL71w30UcLM6aOVxL4IxCT/se4PVK76S+XxZ" +
            "THdXLcm35D8ukhKFMIIFZDCCBEygAwIBAgIQIhCyF0sLEn+7KAUuEbMlCjANBgkq" +
            "hkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJ" +
            "bmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYDVQQLEzJU" +
            "ZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYSAoYykx" +
            "MDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcgMjAxMCBD" +
            "QTAeFw0xMzA5MjQwMDAwMDBaFw0xNjEwMjMyMzU5NTlaMIGnMQswCQYDVQQGEwJV" +
            "UzEVMBMGA1UECBMMUGVubnN5bHZhbmlhMRMwEQYDVQQHEwpQaXR0c2J1cmdoMRUw" +
            "EwYDVQQKFAxDb21wb25lbnRPbmUxPjA8BgNVBAsTNURpZ2l0YWwgSUQgQ2xhc3Mg" +
            "MyAtIE1pY3Jvc29mdCBTb2Z0d2FyZSBWYWxpZGF0aW9uIHYyMRUwEwYDVQQDFAxD" +
            "b21wb25lbnRPbmUwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQC5y6Ca" +
            "qUlVapyS82tOZUyHGpHL8pe3cQcWfnMJOAqpOvlGgun+WeS70Q9fgIYgEbpSICO7" +
            "z4JAn/nPN4jlYkFsiblxSTJxmr2twGel/6NA2lKs2MxTls/zKwMzib2DLa4/zU/Z" +
            "vAVnovlJGNTVlMrYkmtCSDWLeeYvxc7cV7T+ytuy492WMMFJDSziieH/qpEdEEp8" +
            "oGFEEMjAzi4Ob32JAy3VEJDa3rQU9iWesenZDXAqYn+XW2dNTDhRBI2SZRnZ763p" +
            "7jmH8OQjZaA0gkc7bUifPSbSTo0McqwUH9cpTl6Ilwj6cwFwlNkhf3WF0oplTPKU" +
            "9DWe6VDRtR/gM9pzAgMBAAGjggF7MIIBdzAJBgNVHRMEAjAAMA4GA1UdDwEB/wQE" +
            "AwIHgDBABgNVHR8EOTA3MDWgM6Axhi9odHRwOi8vY3NjMy0yMDEwLWNybC52ZXJp" +
            "c2lnbi5jb20vQ1NDMy0yMDEwLmNybDBEBgNVHSAEPTA7MDkGC2CGSAGG+EUBBxcD" +
            "MCowKAYIKwYBBQUHAgEWHGh0dHBzOi8vd3d3LnZlcmlzaWduLmNvbS9ycGEwEwYD" +
            "VR0lBAwwCgYIKwYBBQUHAwMwcQYIKwYBBQUHAQEEZTBjMCQGCCsGAQUFBzABhhho" +
            "dHRwOi8vb2NzcC52ZXJpc2lnbi5jb20wOwYIKwYBBQUHMAKGL2h0dHA6Ly9jc2Mz" +
            "LTIwMTAtYWlhLnZlcmlzaWduLmNvbS9DU0MzLTIwMTAuY2VyMB8GA1UdIwQYMBaA" +
            "FM+Zqep7JvRLyY6P1/AFJu/j0qedMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEE" +
            "AYI3AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAYc1WOc48GABY5iGt" +
            "iUlm6nl0NY639qOQ6EWFoCP/uCxKSflNqPlQCOZCGEjRqeWI6u170KLI7PwuqncK" +
            "X03d24dpRBEeFwkc6aPuByvVscI9A/D9VKFJ+Ny45WzAfxs0UYTatATfhE5Q9PgX" +
            "o7KaFLLHeRkYRizTl5rQ1fvf2u4+4fbeSRDJPviW5crFXulKXILaGPV4LmS7JuQz" +
            "oUE9ECJYDiCtUEpf8IYihnTwXw+YzeP0h7BlVGz6Qvj8Y4eck/y0pvfjapPrczEE" +
            "HKW033iyrPZC4LBuFKPX7IOcDpeBTeAgR6Ngi1xKra4st//66VDDrrVSpptWsB4Y" +
            "BqrLhTCCArgwggGgoAMCAQICCDDzL/lrJKEjMA0GCSqGSIb3DQEBBQUAMBwxGjAY" +
            "BgNVBAMMEUdDLVNVMTE3MDAtNjU0MTUxMB4XDTE3MDEwMTAwMDAwMFoXDTE4MDQz" +
            "MDAwMDAwMFowHDEaMBgGA1UEAwwRR0MtU1UxMTcwMC02NTQxNTEwggEiMA0GCSqG" +
            "SIb3DQEBAQUAA4IBDwAwggEKAoIBAQCOiZPBlGiuejpbN9dV4LN37fReAkDu2VLp" +
            "gclxgZ6L4lfCN+K8dlT+ZyW0snALqKMmT5vKuobVnZp0mPaPAiXuEiui1Qhh7FIU" +
            "PaFP1bW1TiC3Dm/Fne3F0KWTcegPiuHn53HKYo3IsJBnw0q4bM807H1zUKyvX2Ve" +
            "Of9JRhNgCklhjwIF5DakqRE/qMdHfFGsH4Zo03y+PI7rFHDKXTeVlVs6uAS6+oNK" +
            "QEDOlj7nHExFsArifLHCkxn+cKTRFAdo3Vt8w+rbK4OanUGL8S6RO2jJeAkP4Zfw" +
            "MZkjDClnliRputuAV6BxSH3jQWkWV6MjD1rDne8kK5tLs5jhfpkLAgMBAAEwDQYJ" +
            "KoZIhvcNAQEFBQADggEBADYkiHvY2/mdAY1Sy4ib1phY5Fa403iI1nvJ9IzbC/NB" +
            "YGtYa6qioh8wFEjC/zNKJJHUDHTtUvzkRIN/oFUKg/QMGslf+47YHuPH9md7Jwdc" +
            "eL+ViVuBVZMEk/XbCtgdt4+nyquVPa1qpR2PDKkWyaFSx1s8iB+wkufajeBHjxvY" +
            "neynrspZUa13qXbY9Gl1gPdkABTbNl836UFHK2xBjAVgozgBWmkq78R+RbnJJux1" +
            "3R5oMYOd/a7jcUlVS48+z9s6UHitGJqq1X8f9ZmT5NK7YjAwD+7izHDZ26iMAoRO" +
            "G+C4/yr1ukNB9tlb7dhgmFlNsKm3o5CnfE/7dtVljsw=";
    }

}