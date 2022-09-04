using System;
/// <summary>
/// 
/// </summary>
public interface IFtp
{
	public string Delete(string fileName);
	public string Upload(string source, string destination);
	public string Download(string source, string dest);
	public string Rename(string currentName, string newName);


	public string[] Details();
	public string[] List();
	public DateTime Timestamp(string fileName);
	public long Size(string fileName);
	public string Create(string directoryName);

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
