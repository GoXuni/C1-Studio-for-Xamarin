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

namespace FlexChart101
{
    public static class License
    {
        public const string Key =
            "ACABIAIgB3lGAGwAZQB4AEMAaABhAHIAdAAxADAAMQA+me1/D8K7JoSvshfLg+6i" +
            "/zRDS91dMLKm9M+ZhYi188H3kT/9Nd34/fyBm3Nqh4PMwZAwyklTDhT/Vem05vU/" +
            "5E+wljYYNq9mNxLj+0tK3kYqlld51TAm3eeXnXjMaCDfTchp1ohymP/Nr8L5NKf6" +
            "xNS7QfmONrkv05gIJ1X522d+1ANrey3md4QUBOxetubHNbBI4Z6ZO3UXc4XL1vaw" +
            "DDb0mDAlyWamm1/E/qWy7J5V6c6YTHML04rN5lDuQaASWKNpArJQAKCnbN9/ITtw" +
            "7oaaGcSbuGhDawhTP0RliuZym7yeGVJGZkAmjc9LwW/q0YDZsbIsuyM+u2a7/drV" +
            "Pp74nxkyFnB1M9hZCtvhwOozaPbHbvpgdf3M5KajK3MqVpoYgqMXhgbnPh3r1cJq" +
            "W6hmqsMH6QaFkMLKP+9YVKckQoKYGT7wKU9Q8ukh2LTHN7eiXfh2yV/uLGScT4ul" +
            "r3I7imS7dSzCfUD+tm8CbDvmWe2lO1r8s3Wc5W/qJg0IKgph92/aeDhmTq3ET2mE" +
            "MBtynP4olDNS9txDT3STieTcEqP5eTp03jHKQujIBo24FzM42+XeOhysZyVnax5A" +
            "xmgPGSCSilbluQtLL/YpLkUMhYTRVY2g+yvdcuhdC+Q1UJTQ8STO3PYhxfFaCaz9" +
            "OZqP8Y8AMS3evmUzxlN6MjCCBVUwggQ9oAMCAQICEEEDeNImNll6Ftsmxr0QlIsw" +
            "DQYJKoZIhvcNAQEFBQAwgbQxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5WZXJpU2ln" +
            "biwgSW5jLjEfMB0GA1UECxMWVmVyaVNpZ24gVHJ1c3QgTmV0d29yazE7MDkGA1UE" +
            "CxMyVGVybXMgb2YgdXNlIGF0IGh0dHBzOi8vd3d3LnZlcmlzaWduLmNvbS9ycGEg" +
            "KGMpMTAxLjAsBgNVBAMTJVZlcmlTaWduIENsYXNzIDMgQ29kZSBTaWduaW5nIDIw" +
            "MTAgQ0EwHhcNMTQxMjExMDAwMDAwWhcNMTUxMjIyMjM1OTU5WjCBhjELMAkGA1UE" +
            "BhMCSlAxDzANBgNVBAgTBk1peWFnaTEYMBYGA1UEBxMPU2VuZGFpIEl6dW1pLWt1" +
            "MRcwFQYDVQQKFA5HcmFwZUNpdHkgaW5jLjEaMBgGA1UECxQRVG9vbHMgRGV2ZWxv" +
            "cG1lbnQxFzAVBgNVBAMUDkdyYXBlQ2l0eSBpbmMuMIIBIjANBgkqhkiG9w0BAQEF" +
            "AAOCAQ8AMIIBCgKCAQEAwQL2ymVbspWkCpEHpVUHtcmbz5rrTHvwdlY2a8COz96u" +
            "anuluHwz0di4RVNGPwfhtpfEViriLvl7mQ2vuz6cZsnlR8zoKV2pt5GxDjO9Fvqe" +
            "l+u1w4HB9g7HTCh5hB8jpXMtXOE9saNQMrqp0dkt/8Ry9Igq9Fu7cgs4TeS67HTu" +
            "BCRv76utIFTIkpdTydbxz4r72x9aodg9vwUXYhrNbGGZ8h0igM0rKOvev/AifeNB" +
            "6Omp9qaIc2xT87bopLQRy8JLkIU4oNPq+92cCR6TeTItZ5/5xr9xsWjvi9rBga2b" +
            "DbDPD+FzCUA0hBoIDHP7kkdBndISDwstJn4LwThP7wIDAQABo4IBjTCCAYkwCQYD" +
            "VR0TBAIwADAOBgNVHQ8BAf8EBAMCB4AwKwYDVR0fBCQwIjAgoB6gHIYaaHR0cDov" +
            "L3NmLnN5bWNiLmNvbS9zZi5jcmwwZgYDVR0gBF8wXTBbBgtghkgBhvhFAQcXAzBM" +
            "MCMGCCsGAQUFBwIBFhdodHRwczovL2Quc3ltY2IuY29tL2NwczAlBggrBgEFBQcC" +
            "AjAZDBdodHRwczovL2Quc3ltY2IuY29tL3JwYTATBgNVHSUEDDAKBggrBgEFBQcD" +
            "AzBXBggrBgEFBQcBAQRLMEkwHwYIKwYBBQUHMAGGE2h0dHA6Ly9zZi5zeW1jZC5j" +
            "b20wJgYIKwYBBQUHMAKGGmh0dHA6Ly9zZi5zeW1jYi5jb20vc2YuY3J0MB8GA1Ud" +
            "IwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j0qedMB0GA1UdDgQWBBQAWvCtpdR4NfWE" +
            "EqgsBQ74VhuOjjARBglghkgBhvhCAQEEBAMCBBAwFgYKKwYBBAGCNwIBGwQIMAYB" +
            "AQABAf8wDQYJKoZIhvcNAQEFBQADggEBAIjCmFo3jlvlWIqxF8IDqFtV6oyE0ImY" +
            "vriarF1i/DeCwXig4IOiIzqRaHLU2hR3Yulyv0+N8YnnllfixmWqjF5+VOkeCdfw" +
            "w8m4qkMGyTtaSGIS7rl8HBv6D3BAcwx+BjSCMcgBDZkR/Y8npNNIVy+PbjCHvd2z" +
            "KpyaPb3R+nAO0doXaMTmmr+1AE4ny8OQ3jrC3ioyEbqcik6Bz0qeDIst0Q7tXfgo" +
            "zU1v6w30mSpNZc2g2qU5/tCNgfCXDsq7tbeQgYr5/WQ/XGpMGlfCwETmwuWe6M/4" +
            "kCpXxoqUEkMpEjciGWsb0IlSaoU2GZnZ/lATmMC89B5d68ucxiKomuAwggLGMIIB" +
            "rqADAgECAgQO7u7uMA0GCSqGSIb3DQEBBQUAMCUxIzAhBgNVBAMMGkdDLVh1bmkg" +
            "SW50ZXJuYWwgRGV2ZWxvcGVyMB4XDTE3MDEwMTEzMTI0N1oXDTM3MTIzMTEzMTI0" +
            "N1owJTEjMCEGA1UEAwwaR0MtWHVuaSBJbnRlcm5hbCBEZXZlbG9wZXIwggEiMA0G" +
            "CSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDYlJakwdcnFgj846/q+DQB/Qt5GCOV" +
            "9mRELcwJCQ/VN7d1N0n8BBKZ//ZpthZEU0oq6v7xLmO33ztFo1Pwli6P6d+Z725P" +
            "vI4O6p+77OLxYiDS8RWvjZTejl5ehyosQcdsY8vsGQ148ubeXBgOYKekLz7N9TOO" +
            "rZ45e6YXZDrzOmkhQKlBiTTP57ic+7EoSyY6jt9lX0E6cIhQwJGz4lI5iIBIHFwY" +
            "KXMqSqABNtPNlVbgIeIZAqDaxiPZcQY+qxjtS2QxGKpgUKCMdxIZlDGx0tUo/JEU" +
            "SAgQZ8ceU1AZqJwfRjgTXzEJ6BooNXC6FIMrgLd2MTecv1uzEoOWt93LAgMBAAEw" +
            "DQYJKoZIhvcNAQEFBQADggEBAGz/7Zi6HqJW+mFc0HPenbEi8b/pwDaVn+HGyLiX" +
            "qYGMxnXGN+c8sN4ifRGWNgB2glb/k4gFc1M07wi3T5B2GGOJWDKjwuVKAyY8fA+8" +
            "OfE7CrfAhG2hq2rb/vmrqFDRfUFZV7i/4am48EBJhWK/epShVouDwTlVqlHvpxEm" +
            "APuX86tAlTR5GouuAqLFMtqJr8+PkQI4ozoWVrQPpJgOJdnCUSyKBJBz97mtNtIW" +
            "MM3GcdQBfYyvDD4MUvUohdPbQ2yAXY7gGFLkGW1ph2CknePJ4GyxaVoqN0TyQwdy" +
            "WEvHySKMrBcRc4WO7z6xLOYXLde1jDUzoxIr7c1o2cv7RDs=";
    }

}