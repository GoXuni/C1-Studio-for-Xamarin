using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace FlexGrid101
{
    public static class License
    {
        public const string Key =
            "AB4BHgIeB4ZGAGwAZQB4AEcAcgBpAGQAMQAwADEAZdlJ/JxoiLpx1iDFGl5sLcGr" +
            "RU/tIP8fm8XrLqnpAU25OVA4hfqaYgyzB79ZO7x1hZRsfs1sySJTEwZi0LaWKH6B" +
            "QiHKNNYoXmGhcZ6d5QJwLYtdwasRAHEGO1b6FnN5xEktFxpTsGoUaHvnOVmyEW9D" +
            "GNRlwX86gVJa4impc4w/mRGLIKx1yLCSazszt4qziLP4NkoJLaXvSCQS/8/Xzcgi" +
            "miXilFMtYgUA7hgIst+xUXTt1pDNoQVYEUQoYiA1hXz5bBBI2l9x034y4Pz33+E8" +
            "KWWGu9EtGJCXcajHdA/rS2yM7Y09ki7w3IPwdOpPM6bDCpVdmzq/llB1LBZV8Cyq" +
            "9/eYdhVkpYYQNGnps5N95xhgpNapZAKdTkVpsMLX0X+rZk5iMgMBEFJnhlUz3G7y" +
            "OnMNXuuo0mHD0Duy275rfW0grkG8YWyVFuYsqnIKVxiSik7qOBBsjZytY6AcSZtx" +
            "ADhR1IRbvn5XSmJ5Ut1IIv4PUWCD3ZsX4MdqqVkLoWMsG8wYpI37utBL29kDIFs3" +
            "5CEtEZn6rh1RNV6CSSNlMqmcKqjuOlmInPIvjZRKE57U8MMj+VOzR6xaf14RJrU0" +
            "EAO9uq6anZYY+9HXooVngYMUgPVm3eqc0C+3hR4l9+4/zBv0JZ9K8aO79gb3fGeY" +
            "6DXjMQjllDHG0Wo0VCEwggVkMIIETKADAgECAhAiELIXSwsSf7soBS4RsyUKMA0G" +
            "CSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVyaVNpZ24s" +
            "IEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5BgNVBAsT" +
            "MlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20vcnBhIChj" +
            "KTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmluZyAyMDEw" +
            "IENBMB4XDTEzMDkyNDAwMDAwMFoXDTE2MTAyMzIzNTk1OVowgacxCzAJBgNVBAYT" +
            "AlVTMRUwEwYDVQQIEwxQZW5uc3lsdmFuaWExEzARBgNVBAcTClBpdHRzYnVyZ2gx" +
            "FTATBgNVBAoUDENvbXBvbmVudE9uZTE+MDwGA1UECxM1RGlnaXRhbCBJRCBDbGFz" +
            "cyAzIC0gTWljcm9zb2Z0IFNvZnR3YXJlIFZhbGlkYXRpb24gdjIxFTATBgNVBAMU" +
            "DENvbXBvbmVudE9uZTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALnL" +
            "oJqpSVVqnJLza05lTIcakcvyl7dxBxZ+cwk4Cqk6+UaC6f5Z5LvRD1+AhiARulIg" +
            "I7vPgkCf+c83iOViQWyJuXFJMnGava3AZ6X/o0DaUqzYzFOWz/MrAzOJvYMtrj/N" +
            "T9m8BWei+UkY1NWUytiSa0JINYt55i/FztxXtP7K27Lj3ZYwwUkNLOKJ4f+qkR0Q" +
            "SnygYUQQyMDOLg5vfYkDLdUQkNretBT2JZ6x6dkNcCpif5dbZ01MOFEEjZJlGdnv" +
            "renuOYfw5CNloDSCRzttSJ89JtJOjQxyrBQf1ylOXoiXCPpzAXCU2SF/dYXSimVM" +
            "8pT0NZ7pUNG1H+Az2nMCAwEAAaOCAXswggF3MAkGA1UdEwQCMAAwDgYDVR0PAQH/" +
            "BAQDAgeAMEAGA1UdHwQ5MDcwNaAzoDGGL2h0dHA6Ly9jc2MzLTIwMTAtY3JsLnZl" +
            "cmlzaWduLmNvbS9DU0MzLTIwMTAuY3JsMEQGA1UdIAQ9MDswOQYLYIZIAYb4RQEH" +
            "FwMwKjAoBggrBgEFBQcCARYcaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYTAT" +
            "BgNVHSUEDDAKBggrBgEFBQcDAzBxBggrBgEFBQcBAQRlMGMwJAYIKwYBBQUHMAGG" +
            "GGh0dHA6Ly9vY3NwLnZlcmlzaWduLmNvbTA7BggrBgEFBQcwAoYvaHR0cDovL2Nz" +
            "YzMtMjAxMC1haWEudmVyaXNpZ24uY29tL0NTQzMtMjAxMC5jZXIwHwYDVR0jBBgw" +
            "FoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisG" +
            "AQQBgjcCARsECDAGAQEAAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQBhzVY5zjwYAFjm" +
            "Ia2JSWbqeXQ1jrf2o5DoRYWgI/+4LEpJ+U2o+VAI5kIYSNGp5Yjq7XvQosjs/C6q" +
            "dwpfTd3bh2lEER4XCRzpo+4HK9Wxwj0D8P1UoUn43LjlbMB/GzRRhNq0BN+ETlD0" +
            "+BejspoUssd5GRhGLNOXmtDV+9/a7j7h9t5JEMk++JblysVe6UpcgtoY9XguZLsm" +
            "5DOhQT0QIlgOIK1QSl/whiKGdPBfD5jN4/SHsGVUbPpC+Pxjh5yT/LSm9+Nqk+tz" +
            "MQQcpbTfeLKs9kLgsG4Uo9fsg5wOl4FN4CBHo2CLXEqtriy3//rpUMOutVKmm1aw" +
            "HhgGqsuFMIICuDCCAaCgAwIBAgIIX9Y1szGAMXswDQYJKoZIhvcNAQEFBQAwHDEa" +
            "MBgGA1UEAwwRR0MtU1UxMTcwMC02NTQxNTEwHhcNMTcwMTAxMDAwMDAwWhcNMTgw" +
            "NDMwMDAwMDAwWjAcMRowGAYDVQQDDBFHQy1TVTExNzAwLTY1NDE1MTCCASIwDQYJ" +
            "KoZIhvcNAQEBBQADggEPADCCAQoCggEBALiOM4LDPPVWDD9/qfWTg59DWiVXtg/b" +
            "ERcH721RA0mTAdAANP6fD9jkYdU5PkVmrDnbu6zzNT+I3L2HX6ndWUUbM9k63C3V" +
            "mnHESel7ww/0BeOyeFY2an7zolW8uGFo4y2KuPhJgXfKosrFcoUomCbK3Zpnt8Ec" +
            "etqAS7LJfYK/QLG94hqaN7FvMXR39zU4tuTMizxCwV1hhKqMqcYXl2j8bxdOuRH9" +
            "sL5TRGnRfQ10WsHbNgysguqERvNbDaVzZh2p7AMFuPdPuBAAKkvtwGTGKi8F+E9k" +
            "kBS4feggBrq6ZQ2rr3xQITZguUgtVZJAfbs5i1S4ZiJxWhqcS2ydGwMCAwEAATAN" +
            "BgkqhkiG9w0BAQUFAAOCAQEACBNZtuJqS/Lk66m0PRYLWMylnlCqBRzggFivv3fD" +
            "C85khAQises1ytWyja2lCMVpiv+5ipzGLCImyoUHbFZCG+sTODTwwFP5FKUR+rgz" +
            "BzPcbCEUIMStDAdGujBrbaH7LTR9pLZL8eqQnD/UE0StTBuk2Sd9Df4TVw/sbhPR" +
            "HoJ+QrWzB/TLGwngtQ/CLvmOjj0rL8fQmcrNsP3TqVUsZWOXFCLSPj/sSyE4Ko7t" +
            "+a9EMc9fVAIZjVPSPrcb1dc07HN5j89IUY69RueDa8VbucOMt5J/m1f5/5faeOn1" +
            "iwUkue0l6fgA/VLfN9BclKMVDaw7FLCDMQCL1ll4JF0png==";
    }

}