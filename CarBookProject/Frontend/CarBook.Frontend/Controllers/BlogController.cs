using System.Text;
using CarBook.Dto.BlogDTOs;
using CarBook.Dto.CommentDTOs;
using CarBook.Dto.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Frontend.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Kullanici Yorumlarimiz";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/Blog/GetAllBlogWithAuthor");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGetAllBlogWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();

        }

        public async Task<IActionResult> BlogDetail(string id)
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Kullanici Yorumlarimiz ve Bloglar";
            ViewBag.blogId = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult CreateComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.CreatedTime = DateTime.UtcNow;
            createCommentDto.BlogId = ViewBag.blogId;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7070/api/Comment", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();

        }
    }

    }

