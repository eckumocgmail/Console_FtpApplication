using System;
using System.Collections.Concurrent;

public class FtpServer
{ 

	private int Port = 21;

	  
	public FtpServer(int Port = 21)
    {
		this.Port = Port;
    }

    public string GetUrl(string host, string username)
	{
		return $"ftp://{host}:21/{username}";
	}

	public void DeleteFile(string path)
	{
		throw new NotImplementedException();
	}

	public byte[] DownloadFile(string path)
	{
		throw new NotImplementedException();
	}

	public long GetFileSize(string path)
    {
		throw new NotImplementedException();
	}

	public long GetDateTimestamp(string path)
	{
		throw new NotImplementedException();

	}

	public void ListDirectory(string path="/")
	{
		throw new NotImplementedException();

	}
	 
	public void MakeDirectory(string path)
	{
		throw new NotImplementedException();
	}

	public void PrintWorkingDirectory()
	{
		throw new NotImplementedException();
	}

	public void RemoveDirectory(string path)
    {
		throw new NotImplementedException();
	}

	public void RenameFile(string path, string name)
	{
		throw new NotImplementedException();
	}

	public void RenameDirectory(string path, string name)
	{
		throw new NotImplementedException();
	}

	public void UploadFile(string name, byte[] data)
	{
		throw new NotImplementedException();
	}

	public void Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }
}