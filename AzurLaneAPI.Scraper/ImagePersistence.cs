using System.Diagnostics.CodeAnalysis;
using AzurLaneAPI.Domain.Data;
using AzurLaneAPI.Domain.Entities;
using Minio;

namespace AzurLaneAPI.Scraper;

public class ImagePersistence
{
	private static string Endpoint = "minio.myuuiii.com";
	private static string AccessKey = "";
	private static string SecretKey = "";

	private static string BucketName = "azurlane";
	private static DataContext _dataContext;

	public static async Task UploadThumbnails(MinioClient minioClient)
	{
		_dataContext = new DataContext();
		string[] thumbnails = _dataContext.Ships.Select(x => x.ThumbnailImageUrl).ToArray();
		foreach (string thumbnail in thumbnails)
		{
			Console.WriteLine($"Uploading {thumbnail}");
			string fileName = thumbnail.Split('/').Last();
			string filePath = $"thumbnails/{fileName}";
			if (File.Exists(filePath))
				continue;
			using HttpClient client = new();
			HttpResponseMessage response = await client.GetAsync(thumbnail);
			byte[] bytes = await response.Content.ReadAsByteArrayAsync();
			await minioClient.PutObjectAsync(BucketName, filePath, new MemoryStream(bytes), bytes.Length, "image/png");
			Console.WriteLine($"Uploaded {thumbnail}");
			Ship ship = _dataContext.Ships.First(x => x.ThumbnailImageUrl == thumbnail);
			ship.ThumbnailImageUrl = $"https://{Endpoint}/{BucketName}/{filePath}";
			await _dataContext.SaveChangesAsync();
			Console.WriteLine($"Updated {ship.EnglishName}'s thumbnail url to {ship.ThumbnailImageUrl}");
		}
	}

	public static MinioClient GetMinioClient() =>
		new MinioClient()
			.WithEndpoint(Endpoint)
			.WithCredentials(AccessKey, SecretKey)
			.WithRegion("eu-west")
			.WithSSL(true)
			.Build();
}