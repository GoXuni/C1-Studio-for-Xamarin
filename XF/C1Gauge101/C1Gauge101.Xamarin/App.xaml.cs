namespace C1Gauge101
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Xamarin.Forms.NavigationPage(new GaugeSamples());
        }

        protected override void OnStart()
        {
            C1.Xamarin.Forms.Core.LicenseManager.Key = License.Key;
        }
    }

    public static class License
    {
        public const string Key =
           "ABwBHAIcB4RDADEARwBhAHUAZwBlADEAMAAxAIkZy1cj9R1v6sUniBRuag9b3DYZ" +
           "vrWGQu2DgsYdDmXLkpHRxHc1XSucJ617jCBbwUKRYejfoEyeYby3ZsOQxl0/gkja" +
           "/8K6c+Ubrp8vF/1ll5JU7pYSyWGIu2UFDD+HHQLx99VA8PawmYLsV9uETsy4pr7r" +
           "27r36vmD8CgKRHFjji9eqdYT/cuYwmT5ifBKH//Yrhtsk1vaoWqLxdSseiYeE/yu" +
           "28smlxvVWqC6crD1mL6aNB5QJovMgHJhWqB+YjBmrvGRyOfkIepGqeo9VZ5tczdz" +
           "9FzyaVhwxFx7jvBVzocx5fziXDSjXmsvnKLZGCc3MgfiCKTqCseQCgON319m24Kd" +
           "Rq/ZzWV9RGB8mgqP2upq9G3fv6geOVEfPfyW9zN9YUGgkN+xwNuOpV0uIOfy/9rC" +
           "1OdwNDwcoTd2ljTe/oPbLVybNDxFMsG91NsTUnq7m9LFpcNjgZxLyur8EK5TiuE+" +
           "b9mLlZXpUJwX7CAq0CtpzgI7fgHMT8fgiGUTu0UR87JbJ4qYFnBndzr5cTN7w12L" +
           "874ttUoHaZGwmsD8oztwieI8llKX/rGnldQL+Y6vD1GWlET45iq7W3enAB++yXJh" +
           "FXpWheYMuL/CiHuCC/SNtxmZiJURMrfDgfoqCySIYhsZauVYW0smz/bpqV8H6zdw" +
           "qx+KUsSI2d0dIwSjMIIFZDCCBEygAwIBAgIQIhCyF0sLEn+7KAUuEbMlCjANBgkq" +
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
           "BqrLhTCCArgwggGgoAMCAQICCFOkCMl1a8KzMA0GCSqGSIb3DQEBBQUAMBwxGjAY" +
           "BgNVBAMMEUdDLVhVMTE3MDAtMzU4NDM4MB4XDTE3MDEwMTAwMDAwMFoXDTE4MDQz" +
           "MDAwMDAwMFowHDEaMBgGA1UEAwwRR0MtWFUxMTcwMC0zNTg0MzgwggEiMA0GCSqG" +
           "SIb3DQEBAQUAA4IBDwAwggEKAoIBAQCVqA7uCOFUHBNmZaMVYu9LxjiVhALsdHls" +
           "q6oH6puLC6tuU9VWBqX7YeVsrTGv+a3TOfSi7gR+1fXNrS9eV/daLGWg6xQiVMkM" +
           "oY3PurBCwzvLqGhNEwq59wGLHeqBDF0RDy52ui2LSyZKsEE0xkzde1zpQfjhFrAT" +
           "nnMhuewv/HJ9pCADSOOZCyFkaTkKN/nZHoD4l/5RMIGYVF0VfCkYaSwPD1430Cbm" +
           "TV0WxgZkB1L1tXhl5jKVOTPv+mx8HoC1avOG8D9AcJPiJYZ03JEqpK4kAgJ/RNmf" +
           "5PDwqfdDpzzLpQKHi/TWY9gxWiFb6FVds03wGmEQl8kxoKtWnrxpAgMBAAEwDQYJ" +
           "KoZIhvcNAQEFBQADggEBACE/T5jp22k0JPVQ+rcbHItiwuafj+xJAPY5E19ZlkOv" +
           "ELYu0223qGOOla56pRUHlD2JwcRL/6G6Xdv8kxmBOvozh+6ty34SKaY5Cn2dWING" +
           "kABWRBp2ecLNcGihVAHkISXJAelCFMFw8qpAsaEUPLaw4HnjSG6F9HddDrViKxVu" +
           "Ut6Ip6YyPCEwzcly6rd/dPRCcA01bTAcfpL5m6WUQXZj/TWeMm19mmVxTaY0bpIV" +
           "WCCcV4UMzmghIkhEMEMBS0bhgczjGmr8haIUjUEGVIdLaoDfNB9sb/D8zj0960ix" +
           "7xDXgHTYJnaOQf/asUDUftB045RdOeAaxdqnJxR+Pqc=";
    }
}
