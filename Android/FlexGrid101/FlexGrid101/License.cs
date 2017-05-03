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
            "AB4BHgIeB4ZGAGwAZQB4AEcAcgBpAGQAMQAwADEAfOMFWaUCCgiTZFlBoidi5cwQ" +
            "GwuFDxwfJZXNb9UeXnNr8KteTLQpJe6rpyY2ZTlCqdgCIIfdbknSfr+F/Dg+kanE" +
            "LwUlH3pHvKz5VoA9I6eijo5MQwZkWh1fkb56qA2u9s1iC/018nxJl/J+XAsXJNUg" +
            "RJ3rFbVqDBAdk9OiUFLWC/1PxtIYKQw2jUmfj7dqqO81gtwZexBBVsdFJaAzXgdp" +
            "plobwp1UDPoLmNeDPbXle9pIZJuOmuhWxAAes6g6242OCNqlsQEj5XCSE+FrQRfU" +
            "P74T9WfmTy9OCB8SVoJopNEfFkO5GkjnPLEaukLxcSwI8obyywTlhPqBjuF7tTSo" +
            "+zqN5P6/c8+FGOQTHk/1LEZSVEj2bovWpG3Hq9jYAUmNAtjEVhdlJTMtwFzXWMYC" +
            "t7omIT/gieS/AA8Gef8jSCw+jcU/DUltv0DpfdVQme6rqMgPxUcdpM/BNsXbtHax" +
            "6rT8porTGZRegMX2mLN17dlHu8KYs3dRMBCGrEnY0qkduW2YhVRrq544fjWEu/dK" +
            "CqnEfqhztmmwqKw2I6Z/LwtnxJFfpbBaXquOaFbt9t3LH5MOq+QS9y2bwh140fdK" +
            "f62uj6BNF75c/NvitniUc7bum1DZ/+Vgz4d79c/gI7UW63IcfRFp7FMOB4Wtbe5y" +
            "8lcdyz2frM1xCNkQrM4wggVkMIIETKADAgECAhAiELIXSwsSf7soBS4RsyUKMA0G" +
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
            "HhgGqsuFMIICuDCCAaCgAwIBAgIIa2xOJwM7iucwDQYJKoZIhvcNAQEFBQAwHDEa" +
            "MBgGA1UEAwwRR0MtU1UxMTcwMC02NTQxNTEwHhcNMTcwMTAxMDAwMDAwWhcNMTgw" +
            "NDMwMDAwMDAwWjAcMRowGAYDVQQDDBFHQy1TVTExNzAwLTY1NDE1MTCCASIwDQYJ" +
            "KoZIhvcNAQEBBQADggEPADCCAQoCggEBAKa9FqCv2aSYmRqNwXhV+iWUqm9FGNfb" +
            "cQLEmSlJYTLTtvvSIePhJHUDf0czAr8Nb3PKoNDF7h0hm9Y+83H/iWLQCZF6pEw6" +
            "IJvR5Oa7oG9j3XqXgsQgQEU+81cW37MAxdPEhPhGS0azAgb90ePjcsljH2Mt1O2B" +
            "TB5IS4YawuI6d3RchefZfAm5wehmB9Hyy8dMKfhosdhOmWWrrBl3lQwZhD/tbntR" +
            "FJyHedz2aBJJwcUTBhr8mDinTxldXCXbB7agAcubB+cjecj9Hbmvy25O/SXT9eV2" +
            "x+asKx5z7twS1mE0HBXkhgVlTKdlPgvZBj3p5GurDd9rJ/x2c/pZk70CAwEAATAN" +
            "BgkqhkiG9w0BAQUFAAOCAQEApXKwmo0ce+5DsXqHSNslgzyIOIQxXt4DkebIZTMj" +
            "Uk4FNqFl1d7DkaSnPMfWLGPLvtFRUDF0+oW5aOjC375cZRM/0mb9K9wLjVb1mfdj" +
            "3umyVcJWvAonHD6KH+LN7gZaItSZzZiWyWm0ibylCTgESv1KvxWkWB7RPWn1/tFU" +
            "ZzaQ1qV3sTYvLMrlUWaWTN5hpc/IOECL4qHOb0UPKbgzBZfrc/jRh8fgUXgDcYUE" +
            "OXlO3rjKBmOFb2I7L4KSn/aix2rZRezif98yOEutq8vFSx5S6gV45u97kGsfXo5H" +
            "ygXEtN63/m/EtU9WmktW9ebp8nJ1a2f79R/nacgKLfjAOQ==";
    }

}