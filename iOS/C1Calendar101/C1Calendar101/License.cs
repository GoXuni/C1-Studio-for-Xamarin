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
            "ACIBIgIiB3tDADEAQwBhAGwAZQBuAGQAYQByADEAMAAxACwPWP1LEmOFMOwXEUtO" +
            "XMaK/YRE7qtMDZE7vtkweY7SVi3vxqJT1y22WSjlhsBoa91K2lr11aP5P598aKSK" +
            "QeM8+urbhN5U26l748XRFYdkX13eZGp/drQcCe2xS1qBvUTmK9F19s217IZkTSWC" +
            "Fn6pgVo7i94h2FxO+rM7ugr7aFwz8Ien0HrcHdmMSfn5hLl4hKKfqJI6NdKKKUbX" +
            "YNYH5jkEdJT4AH1meUYBXVNvPANm0TK8rvgDfOkhJ70Ve++PXfliouxtQ/zdIs74" +
            "9mYEWvrlhArVe7BEGrF6N+0BgSi5rAIAKFWRQ/rSprF/4qJXHFc+oU/BBMf+L044" +
            "rhNeGBOHWhBWdxEBr6TIq4AWZdiCuLHPE+lgqPt+zSU02UmcXAzdvA4zbuFdqUZJ" +
            "fGQ4yKuvqcdxXHS2Vw5OSW7XLoJSOCvCvMPPlhvKc48wNO7dHUi57myEbji4vtpt" +
            "eqIG6fwpbE430tAC9jUgkyDiVE9KjNwWw+QcE3tSMr1S6ae7H5dPmx9dgYVwF9S8" +
            "5mdA04VG9CD42aNkWL01XI8RkF6RPIm1OyQbOjB9Yart8X/BUVQf1HLChUZMtyjz" +
            "jxV3G0IHygpq8BzaEjlg3aoQielG8fGvGDWacuc0VLAHk81goxyhhixVrWhLQE3d" +
            "SUbkeMSomP3v1Suo/kcfop1YMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCU" +
            "izANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlT" +
            "aWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYD" +
            "VQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3Jw" +
            "YSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcg" +
            "MjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYD" +
            "VQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkt" +
            "a3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZl" +
            "bG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEB" +
            "AQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P" +
            "3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W" +
            "+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5Lrs" +
            "dO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ9" +
            "40Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGB" +
            "rZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJ" +
            "BgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRw" +
            "Oi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcD" +
            "MEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUF" +
            "BwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUF" +
            "BwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNk" +
            "LmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYD" +
            "VR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg1" +
            "9YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgw" +
            "BgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQ" +
            "iZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J" +
            "1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe9" +
            "3bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d" +
            "+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7o" +
            "z/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsYw" +
            "ggGuoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJTEjMCEGA1UEAwwaR0MtWHVu" +
            "aSBJbnRlcm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMTMxMjQ3WhcNMzcxMjMxMTMx" +
            "MjQ3WjAlMSMwIQYDVQQDDBpHQy1YdW5pIEludGVybmFsIERldmVsb3BlcjCCASIw" +
            "DQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAIzwnoVCG0zXXR06DO8mThnicuje" +
            "o//Inb/yi83lqQyXhGahTRol3hdCo0GfgXRuJ6nHBKtXLc3MJRgyWMN3rmqZdfa/" +
            "ES5/OEbFXkyc9xDr3/BTtxREwpF//LYRXdER6TwB5/ZlZ1zG9370O36EsIUDlPmC" +
            "sW6gmbwdfijy7Op36hvW3+RsLm7obPHoR8i+YqNxfGN/njQjw0g4Q+bHEVp2lRG7" +
            "3sqifs6BVtxZ+EubVoXGyvIBWOhc6J93d8dtGHsPH+pg/1Z3KLE0ASZUyyFTdR68" +
            "xsSrG5DcxK2wFivZtSxzc3W0B826YLglXvCFUnxoqWZUFNmWILZLwJCjRc0CAwEA" +
            "ATANBgkqhkiG9w0BAQUFAAOCAQEAP3ciCHL5RGifF3/64Fu+5JUu9kWOS1uZLY8n" +
            "4yrIp+uDrd8eO2fsgRPBD86ouFZoHL9KyVuBDdGPfxA/7WHuG2yesxNI4QmCJg9L" +
            "mJqwjqAiDY2S9/hBxMDcHxfq+JwrCW9UhERCsZilths6+gFW1leIuHcegnbeSwDV" +
            "fxaCao95klP36SvnX7l1erZpSmJl8pmMSyMeHx4pBiUW5NS4MMbe3wR0sy8heh0f" +
            "KpdZRTck8jV3NI02thPkq3HoXlt/6qwuvCKtcJSQIZXN5Ei/W2611SLgD9BTVc6w" +
            "1wMR/zwq0ahMVi3h25f4sgyUNyAYj+Y+AbSSXNl9NoeMw82DFg==";
    }

}