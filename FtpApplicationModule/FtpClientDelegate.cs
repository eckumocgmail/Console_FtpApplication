using System;

/// <summary>
/// 
/// </summary>
public class FtpClientDelegate : IFtp
{
	private IFtp delegated { get; set; }

	public string Delete(string fileName)
		=> delegated.Delete(fileName);
	public string Upload(string source, string destination)
		=> delegated.Upload(source, destination);
	public string Download(string source, string dest)
		=> delegated.Download(source, dest);
	public string Rename(string currentName, string newName)
		=> delegated.Rename(currentName, newName);
	public string[] Details()
		=> delegated.Details();
	public string[] List()
		=> delegated.List();
	public DateTime Timestamp(string fileName)
		=> delegated.Timestamp(fileName);
	public long Size(string fileName)
		=> delegated.Size(fileName);
	public string Create(string directoryName)
		=> delegated.Create(directoryName);
}


 