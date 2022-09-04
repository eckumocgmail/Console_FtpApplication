using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

public class FtpClient : IFtp
{
	private string username;
	private string password;
	private string uri;
	private int bufferSize = 1024;

	public bool Passive = true;
	public bool Binary = true;
	public bool EnableSsl = false;
	public bool Hash = false;

	public FtpClient(string uri, string userName, string password)
	{
		this.uri = uri;
		this.username = userName;
		this.password = password;
	}


	public string ChangeWorkingDirectory(string path)
	{
		uri = PathCombine(uri, path);

		return PrintWorkingDirectory();
	}

	public string Delete(string fileName)
	{
		var request = createRequest(PathCombine(uri, fileName), WebRequestMethods.Ftp.DeleteFile);
		return GetStatus(request);
	}

	public string Download(string source, string dest)
	{
		var request = createRequest(PathCombine(uri, source), WebRequestMethods.Ftp.DownloadFile);
		byte[] buffer = new byte[bufferSize];
		using (var response = (FtpWebResponse)request.GetResponse())
		{
			using (var stream = response.GetResponseStream())
			{
				using (var fs = new FileStream(dest, FileMode.OpenOrCreate))
				{
					int readCount = stream.Read(buffer, 0, bufferSize);

					while (readCount > 0)
					{
						if (Hash)
							Console.Write("#");

						fs.Write(buffer, 0, readCount);
						readCount = stream.Read(buffer, 0, bufferSize);
					}
				}
			}
			return response.StatusDescription;
		}
	}


	public DateTime Timestamp(string fileName)
	{
		var request = createRequest(PathCombine(uri, fileName), WebRequestMethods.Ftp.GetDateTimestamp);
		using (var response = (FtpWebResponse)request.GetResponse())
		{
			return response.LastModified;
		}
	}


	public long Size(string fileName)
	{
		var request = createRequest(PathCombine(uri, fileName), WebRequestMethods.Ftp.GetFileSize);

		using (var response = (FtpWebResponse)request.GetResponse())
		{
			return response.ContentLength;
		}
	}


	public string[] List(string path)
	{
		var list = new List<string>();
		var request = createRequest(WebRequestMethods.Ftp.ListDirectory);
		using (var response = (FtpWebResponse)request.GetResponse())
		{
			using (var stream = response.GetResponseStream())
			{
				using (var reader = new StreamReader(stream, true))
				{
					while (!reader.EndOfStream)
					{
						list.Add(reader.ReadLine());
					}
				}
			}
		}
		return list.ToArray();
	}



	public string[] Details()
	{
		var list = new List<string>();
		var request = createRequest(WebRequestMethods.Ftp.ListDirectoryDetails);
		using (var response = (FtpWebResponse)request.GetResponse())
		{
			using (var stream = response.GetResponseStream())
			{
				using (var reader = new StreamReader(stream, true))
				{
					while (!reader.EndOfStream)
					{
						list.Add(reader.ReadLine());
					}
				}
			}
		}
		return list.ToArray();
	}


	public string Create(string directoryName)
	{
		var request = createRequest(PathCombine(uri, directoryName), WebRequestMethods.Ftp.MakeDirectory);
		return GetStatus(request);
	}
	public string PrintWorkingDirectory()
	{
		var request = createRequest(WebRequestMethods.Ftp.PrintWorkingDirectory);

		return GetStatus(request);
	}

	public string RemoveDirectory(string directoryName)
	{
		var request = createRequest(PathCombine(uri, directoryName), WebRequestMethods.Ftp.RemoveDirectory);

		return GetStatus(request);
	}

	public string Rename(string currentName, string newName)
	{
		var request = createRequest(PathCombine(uri, currentName), WebRequestMethods.Ftp.Rename);

		request.RenameTo = newName;

		return GetStatus(request);
	}

	public string Upload(string source, string destination)
	{
		var request = createRequest(PathCombine(uri, destination), WebRequestMethods.Ftp.UploadFile);

		using (var stream = request.GetRequestStream())
		{
			using (var fileStream = System.IO.File.Open(source, FileMode.Open))
			{
				int num;

				byte[] buffer = new byte[bufferSize];

				while ((num = fileStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					if (Hash)
						Console.Write("#");

					stream.Write(buffer, 0, num);
				}
			}
		}

		return GetStatus(request);
	}

	public string UploadFileWithUniqueName(string source)
	{
		var request = createRequest(WebRequestMethods.Ftp.UploadFileWithUniqueName);

		using (var stream = request.GetRequestStream())
		{
			using (var fileStream = System.IO.File.Open(source, FileMode.Open))
			{
				int num;

				byte[] buffer = new byte[bufferSize];

				while ((num = fileStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					if (Hash)
						Console.Write("#");

					stream.Write(buffer, 0, num);
				}
			}
		}

		using (var response = (FtpWebResponse)request.GetResponse())
		{
			return Path.GetFileName(response.ResponseUri.ToString());
		}
	}

	private FtpWebRequest createRequest(string method)
	{
		return createRequest(uri, method);
	}

	private FtpWebRequest createRequest(string uri, string method)
	{
		var r = (FtpWebRequest)WebRequest.Create(uri);

		r.Credentials = new NetworkCredential(username, password);
		r.Method = method;
		r.UseBinary = Binary;
		r.EnableSsl = EnableSsl;
		r.UsePassive = Passive;

		return r;
	}

	private string GetStatus(FtpWebRequest request)
	{
		using (var response = (FtpWebResponse)request.GetResponse())
		{
			return response.StatusDescription;
		}
	}

	private string PathCombine(string path1, string path2)	
		=> Path.Combine(path1, path2).Replace("\\", "/");
	

	public string[] List()
	{
		throw new NotImplementedException();
	}
}




/**
public WwwFileClient(string host, string username, byte[] secret)
	{
		this.url = $"ftp://{host}:21/{username}";
		
		InitializeComponent();
	}

	private void InitializeComponent()
	{
	}
AppendFile	
Представляет метод протокола FTP APPE, используемый для добавления файла к существующему файлу на FTP-сервере.

DeleteFile	
Представляет метод протокола FTP DELE, используемый для удаления файла с FTP-сервера.

DownloadFile	
Представляет метод протокола FTP RETR, используемый для загрузки файла с FTP-сервера.

GetDateTimestamp	
Представляет метод протокола FTP MDTM, который используется для получения штампа даты и времени из файла на FTP-сервере.

GetFileSize	
Представляет метод протокола FTP SIZE, используемый для определения размера файла на FTP-сервере.

ListDirectory	
Представляет метод протокола FTP NLIST, который выдает краткий список файлов на FTP-сервере.

ListDirectoryDetails	
Представляет метод протокола FTP LIST, который выдает подробный список файлов на FTP-сервере.

MakeDirectory	
Представляет метод протокола FTP MKD, используемый для создания каталога на FTP-сервере.

PrintWorkingDirectory	
Представляет метод протокола FTP PWD, который выводит название текущего рабочего каталога.

RemoveDirectory	
Представляет метод протокола FTP RMD, который производит удаление каталога.

Rename	
Представляет метод протокола FTP RENAME, который переименовывает каталог.

UploadFile	
Представляет метод протокола FTP STOR, используемый для передачи файла на FTP-сервер.

UploadFileWithUniqueName	
Представляет метод протокола FTP STOU, который выгружает файл с уникальным именем на FTP-сервер.


 */
