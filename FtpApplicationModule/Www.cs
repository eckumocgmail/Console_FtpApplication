using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

public class Www
{

	internal Www Authenticate<TDbContext>(params FtpServer[] enumerable) where TDbContext : class
	{
		foreach (var server in enumerable)
		{
			server.Authenticate("admin", "p@ssword");
		}
		return new Www();
	}

	internal static Www Discovery(Func<IEnumerable<FileWebRequest>> getServices)
	{
		return new Www();
	}
	public void ListDirectoryDetails()
	{

		// Get the object used to communicate with the server.
		FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/");
		request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

		// This example assumes the FTP site uses anonymous logon.
		request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

		FtpWebResponse response = (FtpWebResponse)request.GetResponse();
		Stream responseStream = response.GetResponseStream();
		StreamReader reader = new StreamReader(responseStream);

		Console.WriteLine(reader.ReadToEnd());
		Console.WriteLine($"Directory List Complete, status {response.StatusDescription}");

		reader.Close();
		response.Close();
	}

	public async Task UploadFiles()
	{
		// Get the object used to communicate with the server.
		FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
		request.Method = WebRequestMethods.Ftp.UploadFile;

		// This example assumes the FTP site uses anonymous logon.
		request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

		// Copy the contents of the file to the request stream.
		using (FileStream fileStream = File.Open("testfile.txt", FileMode.Open, FileAccess.Read))
		{
			using (Stream requestStream = request.GetRequestStream())
			{
				await fileStream.CopyToAsync(requestStream);
				using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
				{
					Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
				}
			}
		}

	}
	public void ListDirectory()
	{

		// Get the object used to communicate with the server.
		FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/");
		request.Method = WebRequestMethods.Ftp.ListDirectory;

		// This example assumes the FTP site uses anonymous logon.
		request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

		FtpWebResponse response = (FtpWebResponse)request.GetResponse();
		Stream responseStream = response.GetResponseStream();
		StreamReader reader = new StreamReader(responseStream);

		Console.WriteLine(reader.ReadToEnd());
		Console.WriteLine($"Directory List Complete, status {response.StatusDescription}");

		reader.Close();
		response.Close();
	}

 
}

 