using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace C1Gauge101
{
    public static class License
    {
        public const string Key =
            "ABwBHAIcB4RDADEARwBhAHUAZwBlADEAMAAxAKkXbSsRKh/dUN5BfgX1sZkAz9Zu" +
            "+41zVWimsxVLmtrs3Y3FqqzCKURmKlozdXapS8VrsNSbwWKBL25XhBqXYtnclkns" +
            "ZHGPEiOhvwsynr5LSPwqCgil76VT1ehU6DxotuN1sESGNnK+3PWQic+tu+ECZgxO" +
            "rDg18Ozl41pLsq2YtwuQZYL/BGx8vUW+Vb2GGIBwIsctGOwBmcGyPvW7VxfMS8RL" +
            "dzTRiCqCNL5/UHwSd8YKAXRXJ9hGbYUPgrZJQIZQJlVPEI5SDOFEBPvQgJ7flvas" +
            "zOOIPphSu9JZG8rmm5/805en3CEdE/yfM8HW/DhGBLbCQCyqiGPJPq607Z2e5ATD" +
            "mVKpBdDRS4TuJ3X6S/Z2UiJmeSOC8XKimUrpcv8jml0gtq4G0GZdufwIgRuO02Nb" +
            "SNt5xxV4/sJdAVjyn2awQwGQtyXWLQvRlgByFRhYpR6kdN/4AsMIqrWAyo49Ulia" +
            "Dv1Rji3EoTNB/tfqdfVBIoAFe7XR49lrywVDBrEs88prHokYHad3CwC9K++OCEzq" +
            "Sb0NpEuNZCb8Wl0ybbaFF9bYKe2Urof235K23kpiBLy+ekr30IGTr9qlSk8TvQch" +
            "AinrL2kpfSLDn0OubpUDR+/kMoOeorcSeGIbsWEzWNtMdaMkNFfcXiXgs43RqP98" +
            "ItWxwZEPbdWQFaU+MIIFZDCCBEygAwIBAgIQIhCyF0sLEn+7KAUuEbMlCjANBgkq" +
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
            "BqrLhTCCArgwggGgoAMCAQICCAb6gjSYfMIHMA0GCSqGSIb3DQEBBQUAMBwxGjAY" +
            "BgNVBAMMEUdDLVNVMTE3MDAtNjU0MTUxMB4XDTE3MDEwMTAwMDAwMFoXDTE4MDQz" +
            "MDAwMDAwMFowHDEaMBgGA1UEAwwRR0MtU1UxMTcwMC02NTQxNTEwggEiMA0GCSqG" +
            "SIb3DQEBAQUAA4IBDwAwggEKAoIBAQDBI4DrtdvUdsk0Mbv6Beo48fpm0fogRjEa" +
            "YhZhf571qF0KYnJ4HzuMxGmCXp9srakO/ALDeMOmSv1zSmoq+4KtXkiV5axLIea0" +
            "xLwMfeeAHJNHZjFjUGGQQDH+NfWngLGUTtnFywcoS7RGdgCVTiUAbNLi/8WKWASL" +
            "El5ZOIub1gfHAgCyx1JG+xYdkCrmqk1bWoVQldmT6j5Cezaiz4pXOROjNiscE1Gp" +
            "5OdcKNQjp/aUgZdlAW+pN3nIRyxzoU7AFtvt9Lu1+B+nSizRdz0EnUKhgNCjDBFY" +
            "HUOHLIYqvEue6LshaysaJm7gR4xu3D5yZ6zCyc/XLUvMLg7fAKL3AgMBAAEwDQYJ" +
            "KoZIhvcNAQEFBQADggEBABcqSWHRYpngOvQT8YitKgDd0zW2WpM5CQmidtnuK7aS" +
            "U7W/9ls/FLJ5EDGPnUGnQNuwTmM4ylL8Dv/grEVInB3QW8srzrccNRZXPc7Z7zuc" +
            "Ee8iZE/A7DS91Ln1cGn0nXrKmaXzAX0DvvrgHhc8UeXbUA/xa8/eL+4/RwRgGVcs" +
            "itywdw2SwsZWEKiFQpLkTsmEISOLHBl4GyYG1NfFu6uSsRHWmvTLNWYn2CDoBv6i" +
            "+OKEmIC5XZw20Y33nu/1DOzoIrg4ON9r/X5kLPX4ypeuLDPVVMeOlCRdrkAt++/1" +
            "A6ZOjQI4FZjVTs4hNBtLH379V84moz5Hd+aSs9RrS0A=";
    }

}