using C1.Xamarin.Forms.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyBI
{
    public partial class App : Application
	{
		
		public App ()
		{
            
			InitializeComponent();

            LicenseManager.Key =
            "ABABEAIQB2lNAHkAQgBJAF99EeR99TEnGIzKvAUvVHpH5M+ZN+i0H396Yi6sIJzz" +
            "8FxieFpHL0VLKO946hAAEv4YmxJgiewrD+d5MBPQK4hu9Khg8eJ/fooyizWIpvN+" +
            "taciiX/9GCAQ2Vy5iIYMW1wCYBgWxY3FK6Et2efmOyGCk6LqLi58rGXlk8cW1ihi" +
            "KEDHkc0Bx1ig7rS4vTuP+7ClAyzmV8aPkJtwwsUab4rMgeEouqZkiwDxdKrapqVT" +
            "8IXkRszRcfNfS03PalI0ONf9f5hYbEZGzrb6KX/euCsxA261+6DlSScb0oXMjmKm" +
            "jwC6069PHJCSGZAYPO3h+W6gNqhk+N2Fr64ZGoGv0mad0COy+LcrIMF3Xynqly/D" +
            "9gHITKxngF2nSooM4BYVi82MGeca4rbXF1hfIcu1spRwFy5ojgsa18iZmXLnrgCt" +
            "UU5DbIY4d9wQ2xqRt84u+k4Thg3Nqx7qsheySg52sCuCZx/nXB6qnBqQAmLzRVxn" +
            "I8tZsmqOiEK5Tt91RN8HT1+MZHrSUXVnzo5MrTffe0iUnJVZCodsZAqUi7zyUWVN" +
            "w1wmUYSEgKHf1v23wzXzR0xTSkAxxagqdZcCL9A/MBvC/btvtUYXBqmfzWnjh5D0" +
            "eROQAAGp5A9Cja2fPOfqOMUC2FYPPuhRrCryx59AyZWSA+2Yte77DOVtaX+eyjsV" +
            "MIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkqhkiG9w0BAQUFADCB" +
            "tDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJbmMuMR8wHQYDVQQL" +
            "ExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYDVQQLEzJUZXJtcyBvZiB1c2Ug" +
            "YXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYSAoYykxMDEuMCwGA1UEAxMl" +
            "VmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcgMjAxMCBDQTAeFw0xNDEyMTEw" +
            "MDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYDVQQGEwJKUDEPMA0GA1UECBMG" +
            "TWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkta3UxFzAVBgNVBAoUDkdyYXBl" +
            "Q2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZlbG9wbWVudDEXMBUGA1UEAxQO" +
            "R3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDB" +
            "AvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P3q5qe6W4fDPR2LhFU0Y/B+G2" +
            "l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W+p6X67XDgcH2DsdMKHmEHyOl" +
            "cy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5LrsdO4EJG/vq60gVMiSl1PJ1vHP" +
            "ivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ940Ho6an2pohzbFPztuiktBHL" +
            "wkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGBrZsNsM8P4XMJQDSEGggMc/uS" +
            "R0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJBgNVHRMEAjAAMA4GA1UdDwEB" +
            "/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRwOi8vc2Yuc3ltY2IuY29tL3Nm" +
            "LmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcDMEwwIwYIKwYBBQUHAgEWF2h0" +
            "dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUFBwICMBkMF2h0dHBzOi8vZC5z" +
            "eW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUFBwMDMFcGCCsGAQUFBwEBBEsw" +
            "STAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNkLmNvbTAmBggrBgEFBQcwAoYa" +
            "aHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYDVR0jBBgwFoAUz5mp6nsm9EvJ" +
            "jo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg19YQSqCwFDvhWG46OMBEGCWCG" +
            "SAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0B" +
            "AQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQiZi+uJqsXWL8N4LBeKDgg6Ij" +
            "OpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J1/DDybiqQwbJO1pIYhLuuXwc" +
            "G/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe93bMqnJo9vdH6cA7R2hdoxOaa" +
            "v7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d+CjNTW/rDfSZKk1lzaDapTn+" +
            "0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7oz/iQKlfGipQSQykSNyIZaxvQ" +
            "iVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsYwggGuoAMCAQICBA7u7u4wDQYJ" +
            "KoZIhvcNAQEFBQAwJTEjMCEGA1UEAwwaR0MtWHVuaSBJbnRlcm5hbCBEZXZlbG9w" +
            "ZXIwHhcNMTgwNzI2MTU1MDQwWhcNMzkxMjMxMTU1MDQwWjAlMSMwIQYDVQQDDBpH" +
            "Qy1YdW5pIEludGVybmFsIERldmVsb3BlcjCCASIwDQYJKoZIhvcNAQEBBQADggEP" +
            "ADCCAQoCggEBAJNikZ3AdDxlKsBhBXBRbwWrAYt1l88RwYllLHKw4vFE1z3P3yCl" +
            "B32V6rJ+zA1oSqznTseEtounOIrjH7yHsP6XfMcxOSwGrsDHUF/KUKhZ48+6oCIL" +
            "TITW80YFNhijgQTwJ1wFdnVgnhLJyT7uGgW0/65aaj2zEkrsRt0doS1XlRX3Bq8s" +
            "rUIO4prLJiL1ywkieKMtxkEe5SFsdZPJVmoyQd7D/zcKrC6sRLf5TCEWgAEDnJwZ" +
            "u+Cpttgl46kU67q2L9fHJwCCBW17c0jQJFJGguystw12a3NfrHTzRqjViSt/FXew" +
            "lf/WTLzfhTipozd4+7LW2R3gofSQbZx7shkCAwEAATANBgkqhkiG9w0BAQUFAAOC" +
            "AQEAb4qddamhFm3zjEL7tXOjM+Xop/7rMfnOwn6Bw3Mg16ydGX7D61dygAIpfvjk" +
            "GLs7pwNhI+eHxEvo92L1qfztbmLiitktbXxv9Z8uD8+qHnCfhjxESmKSkuzkbAvj" +
            "Y42B2AI6gvRUJHjgZl2YCC6xCZiloS0su0S5Vo4LS8N3x6yf97hpKrNmps0j9vFF" +
            "+UE2T3HlUa0wQbL8eX8eFCk2ruK1C/2qJZ62uzr2Ehe4s2stx5NXQpiwMNDVzCqn" +
            "59J3x7R3lBhMeBvFDkxSR/PC0XgpCEYcKuDeSjDkdf75v8gnIyc2/4pcQ7gK8ZmF" +
            "s7SwAD+2W18rXRIkBt1j+HeEmQ==";

            MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
