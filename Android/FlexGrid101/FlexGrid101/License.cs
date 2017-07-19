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

namespace FlexGrid101
{
    public static class License
    {
        public const string Key =
            "AB4BHgIeB3dGAGwAZQB4AEcAcgBpAGQAMQAwADEAKbkiPldyeutI6zer42z2Gn57" +
            "kGND7B4f1BjzrebqRQCYtqAEVMVkTGTjNV5xK2SPXxqfJrJkbXkjD1nI5jB4f5l0" +
            "iLv9S04YoNk4k2oxxpPsn25cc3z08PIbNNbnnmRdymaQszNdGd8sxM+HCeN7uIX0" +
            "IT6/19nPB5VnL+e9xP3/6bVRNCzmsAhQ/AbT603c2er5D+XiGYhPUcxI6/DIgDmP" +
            "Zb/Whp3l0Ej8bjRPKWcOKgEYMAAXDQKU9dvZ5XsxQ6jJfFcqTXBn+R8pzwyv6XQc" +
            "71tZWv/Sd5G373SuFtF2ujgdfZbuDhk29oxefvccoZodgrhH/DI+1LNOnTTI9SCp" +
            "2uavHbHBHexwzpzA+EbXpPvZje5ETXjqQvMnnnZ7g24OPctQ518P+Ay5Nhgfuqq2" +
            "AXo+A4u7otuY3oqYv28Y/lPMw5y25SPmSAf3S5yFnZI5ausYPUR9P4Vpa1B4Cw81" +
            "RlQ/IaURwoCJ7wWchAHKYqv30pRfcMqvEJY+VwYMBVToxM0u0Iuml1f4cDkOYzId" +
            "6IFRiDQTARS/uQAnYdj3/YQTGOttJsGAj/jDxr2Itt7MTJTomy1JsmO64Vt59eFq" +
            "Pt3guWXl9gYBK3L8Yg54mm/fdBdXVSLsQJpTUTooa1c08wVhMryrQAosKZbpEkDq" +
            "UrNSFVoi7PwP/wF7WJgwggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0G" +
            "CSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVyaVNpZ24s" +
            "IEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5BgNVBAsT" +
            "MlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20vcnBhIChj" +
            "KTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmluZyAyMDEw" +
            "IENBMB4XDTE0MTIxMTAwMDAwMFoXDTE1MTIyMjIzNTk1OVowgYYxCzAJBgNVBAYT" +
            "AkpQMQ8wDQYDVQQIEwZNaXlhZ2kxGDAWBgNVBAcTD1NlbmRhaSBJenVtaS1rdTEX" +
            "MBUGA1UEChQOR3JhcGVDaXR5IGluYy4xGjAYBgNVBAsUEVRvb2xzIERldmVsb3Bt" +
            "ZW50MRcwFQYDVQQDFA5HcmFwZUNpdHkgaW5jLjCCASIwDQYJKoZIhvcNAQEBBQAD" +
            "ggEPADCCAQoCggEBAMEC9splW7KVpAqRB6VVB7XJm8+a60x78HZWNmvAjs/ermp7" +
            "pbh8M9HYuEVTRj8H4baXxFYq4i75e5kNr7s+nGbJ5UfM6CldqbeRsQ4zvRb6npfr" +
            "tcOBwfYOx0woeYQfI6VzLVzhPbGjUDK6qdHZLf/EcvSIKvRbu3ILOE3kuux07gQk" +
            "b++rrSBUyJKXU8nW8c+K+9sfWqHYPb8FF2IazWxhmfIdIoDNKyjr3r/wIn3jQejp" +
            "qfamiHNsU/O26KS0EcvCS5CFOKDT6vvdnAkek3kyLWef+ca/cbFo74vawYGtmw2w" +
            "zw/hcwlANIQaCAxz+5JHQZ3SEg8LLSZ+C8E4T+8CAwEAAaOCAY0wggGJMAkGA1Ud" +
            "EwQCMAAwDgYDVR0PAQH/BAQDAgeAMCsGA1UdHwQkMCIwIKAeoByGGmh0dHA6Ly9z" +
            "Zi5zeW1jYi5jb20vc2YuY3JsMGYGA1UdIARfMF0wWwYLYIZIAYb4RQEHFwMwTDAj" +
            "BggrBgEFBQcCARYXaHR0cHM6Ly9kLnN5bWNiLmNvbS9jcHMwJQYIKwYBBQUHAgIw" +
            "GQwXaHR0cHM6Ly9kLnN5bWNiLmNvbS9ycGEwEwYDVR0lBAwwCgYIKwYBBQUHAwMw" +
            "VwYIKwYBBQUHAQEESzBJMB8GCCsGAQUFBzABhhNodHRwOi8vc2Yuc3ltY2QuY29t" +
            "MCYGCCsGAQUFBzAChhpodHRwOi8vc2Yuc3ltY2IuY29tL3NmLmNydDAfBgNVHSME" +
            "GDAWgBTPmanqeyb0S8mOj9fwBSbv49KnnTAdBgNVHQ4EFgQUAFrwraXUeDX1hBKo" +
            "LAUO+FYbjo4wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisGAQQBgjcCARsECDAGAQEA" +
            "AQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCIwphaN45b5ViKsRfCA6hbVeqMhNCJmL64" +
            "mqxdYvw3gsF4oOCDoiM6kWhy1NoUd2Lpcr9PjfGJ55ZX4sZlqoxeflTpHgnX8MPJ" +
            "uKpDBsk7WkhiEu65fBwb+g9wQHMMfgY0gjHIAQ2ZEf2PJ6TTSFcvj24wh73dsyqc" +
            "mj290fpwDtHaF2jE5pq/tQBOJ8vDkN46wt4qMhG6nIpOgc9KngyLLdEO7V34KM1N" +
            "b+sN9JkqTWXNoNqlOf7QjYHwlw7Ku7W3kIGK+f1kP1xqTBpXwsBE5sLlnujP+JAq" +
            "V8aKlBJDKRI3IhlrG9CJUmqFNhmZ2f5QE5jAvPQeXevLnMYiqJrgMIICxjCCAa6g" +
            "AwIBAgIEDu7u7jANBgkqhkiG9w0BAQUFADAlMSMwIQYDVQQDDBpHQy1YdW5pIElu" +
            "dGVybmFsIERldmVsb3BlcjAeFw0xNzAxMDExMzEyNDdaFw0zNzEyMzExMzEyNDda" +
            "MCUxIzAhBgNVBAMMGkdDLVh1bmkgSW50ZXJuYWwgRGV2ZWxvcGVyMIIBIjANBgkq" +
            "hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAy72P0OOi/GG596GZFU1KiYuHBMxExySt" +
            "8yh8/OA3ovD8Qanzo7Qx9TRW2VOj7iMs0UovNj+ZVqyNqmPwd+OtWTIpbS5fJvsa" +
            "vqt+fuBer9lA5IwVtyxZgb7oXW46GqlcWoLF795Sqeq16Rr+kRcsMCwmWJ9urvzM" +
            "k5M7ayasu6UUgxsb38UHo8m8QDbJ005Sp9lFxjjX35c7b+Z+eqP2cziOzmomNfll" +
            "Kd196UdZVkfCrpio55N2C+JasrnmZe1QnV0MNTw0z4PfyHCkTGjvGAe4EXWRH468" +
            "5EwYeiJZB0KAH6HSE6LRuM+rUbpyPCARXeHVO7I81XRPXYFuyMZBPQIDAQABMA0G" +
            "CSqGSIb3DQEBBQUAA4IBAQCtMoUq94b4eaaxdBjNKaCarnRC5zHeDTruwGL7Kohw" +
            "7Dlsrx/dT3W9Ad5cGDwIjWBQB9fTza1B7cdeDAe01tiK8x36B3K0XdTbrcrHWfzx" +
            "89AAu7UDoYLqsnjmuy7TdscIVWHFvJoBt3JHTl5Tf+rGB7/Uqx3MXiSM43UUrfl9" +
            "RjK65+AOs0iVop/yKRJ4thz5UwEhHabN5Bvv25k5OokP7xyMarQQIGBishH9sq4O" +
            "HjzkmrOIzUyBtHPaHffzt+ddJs0HZYqnwEYlKGqFjOaNwhfIsx0do1gE5tbyZxBU" +
            "+GOXufcNUdwm90Gl1Pr7pKVkiq70REwbBvrnkEWUj9Cw";
    }

}