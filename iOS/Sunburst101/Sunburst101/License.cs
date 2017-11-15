using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Sunburst101
{
    public static class License
    {
        public const string Key =
           "AB4BHgIeB3dTAHUAbgBiAHUAcgBzAHQAMQAwADEAIE6LwLsmssy7Yy65BYugwX/i" +
            "1zaBp2upIvtbF1aP0j6GXx4O2x7fZepuYGOkEkLM2Y5up8ygWX/icdsS/SXNs9+B" +
            "nahJtodNskzu+EY8+Ex/9DyCXVds2giERg2fqzH0JkT9M1diIquriuamPiiP+R9E" +
            "abxLo1+Fm7MrLGicH1Fu2t/BBBU7H2XSNGP+0Zck5o8hKPfo7KdUIdt0+gNR6ND4" +
            "BO4frj5d9vN+SOuQhFEqziGrKr1+aPS/tgeK3pJNl9o4HzWppjjFXWTYLQYbQLmW" +
            "ueyv01Du5vZTteIl852NFbTo4f5ep5EK93vOwH0aQNQwpPUK0jSuMVEOQGpLylxM" +
            "vao5kFL1+ZY3nuC8qy8b209aC1w2hDBPThCufeQTbcxRBRelfTv95YDm5M6rdkf9" +
            "O4OmKWkt6qOV5m8YRDFAmxuyK60Ulah7hSxuYWJFMAVZDRQK+Xl1kOsu4PnCq5mm" +
            "rJ8BoZbREb0opnxqR0vUvN6fwkmFx+l3TYSJ3LrpGphC69IxbwNU1dQWHMsfSwkp" +
            "gSZMkpjpp5d2UutctkDqJNzk0hoA+1ytU+GkxaR8LPtJvAK0JbTTGCbeBhMSi0hR" +
            "gXLeasYDFfZwEmSI/19YUVzwbU6Xq2IUPG1r3Vxv/mYzT5LxoXbN8m6XGJxw7/Z4" +
            "Sr5IYMsM12ZcM7C2aX4wggVVMIIEPaADAgECAhBBA3jSJjZZehbbJsa9EJSLMA0G" +
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
            "dGVybmFsIERldmVsb3BlcjAeFw0xNzA4MTEwOTExNTZaFw0zNzA4MTYwOTExNTZa" +
            "MCUxIzAhBgNVBAMMGkdDLVh1bmkgSW50ZXJuYWwgRGV2ZWxvcGVyMIIBIjANBgkq" +
            "hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAoYiSJNzyNSoyEG/SMrbpLRKWShGIoNz+" +
            "p5nU7trth8xDbzNCeSbfoD7yWlfkvMp6GG3o7YOkq4mMfCNErmkoxkLDGJnzdQlK" +
            "HxytzEmYRE7atK1e6ht1p+dNUA61yAY+v9rvm5jISC+uaYhsQe6Y/UyGVQYIk9iC" +
            "oouZgsaAUBkFiFZJH8wMNTEyWGgTBfq8wr1IdmDz0jU0PEhp136rR4+MD24f49x2" +
            "1EvAqaZJYdVn/JDcAADjSGNnbf7QNt3SEWoibajHFVDPLThEtys0hdjMGdJXsBen" +
            "mkV+aS9Rg4lz/BIm7nrbiEyBrCXfg48sL1Yx1TwCtxOjy6iAPNF5twIDAQABMA0G" +
            "CSqGSIb3DQEBBQUAA4IBAQBSXLB7DDELq/iDmSVRX/KyJoRckI0i0hMUVBE9ZF8X" +
            "qJtkmVeryb3Zpm51a07Xef2fc4arrIUpxkriS8Q2JGLSEhSwmpassKPrFa0HM+Pj" +
            "OyQID+y/+qHPczgWn8HiK8Ikn7KRVB5Fa0BN7QL1Czne59CYYt4/lMRFU1sHVMHS" +
            "woseSzVOa3f7T78ODOOVLl2o/KrxceQoTfyfOU06ZVrX5Q/i/zgz45MkQMBmdFdM" +
            "2nWcVUs1D7+TGujOKohYqK+JyBiA/m4Jpdf3HNtyRPBLhJe8VSucHxXA+nzH+AnH" +
            "92vbvZRj2FV6OP9VUhJMJhoMv+NqAur5SW9jkvFr2R5o";
    }
}