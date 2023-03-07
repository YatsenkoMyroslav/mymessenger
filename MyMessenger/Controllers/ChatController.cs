using BLL.Extensions;
using BLL.Services;
using BLL.Services.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMessenger.Models;
using MyMessenger.ViewModel;

namespace MyMessenger.Controllers;

public class ChatController : Controller
{
    private UserManager<User> _userManager;
    private ChatService _chatService;

    public ChatController(ChatService service, UserManager<User> userManager)
    {
        _chatService = service;
        _userManager = userManager;
    }
        
    [HttpGet]
    [Route("/chat")]
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var userIdentity = User.Identity;
        if (userIdentity is { IsAuthenticated: true })
        {
            //var response = _chatService.GetUsersChat(await _userManager.GetUserByClaimsIdentityNameAsync(userIdentity));

            var response = new List<ChatDto>()
            {
                new()
                {
                    Id = 1,
                    ChatName = "Some chat",
                    Messeges = new List<MessegeDto>()
                    {
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend",
                            SentOn = DateTime.Now
                        },
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend2",
                            SentOn = DateTime.Now
                        },new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend3",
                            SentOn = DateTime.Now
                        },
                    }
                },
                new()
                {
                    Id = 2,
                    ChatName = "Some chat2",
                    Messeges = new List<MessegeDto>()
                    {
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend",
                            SentOn = DateTime.Now
                        },
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend2",
                            SentOn = DateTime.Now
                        },new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend3",
                            SentOn = DateTime.Now
                        },
                    }
                },
                new()
                {
                    Id = 3,
                    ChatName = "Some chat3",
                    Messeges = new List<MessegeDto>()
                    {
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend",
                            SentOn = DateTime.Now
                        },
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend2",
                            SentOn = DateTime.Now
                        },new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3",
                            SentOn = DateTime.Now
                        },
                    }
                }
            };
            foreach (var chat in response)
            {
                Console.WriteLine(chat.Id);
            }
            
            return View(response);
        }
        return Redirect("/");
    }

    [HttpGet]
    [Route("/chat/{id}")]
    public async Task<IActionResult> GetChatById(int id)
    {
        var userIdentity = User.Identity;
        if (userIdentity is { IsAuthenticated: true })
        {
            /*var chat = await _chatService.GetAsync(id);
            var response = new ChatsAndSelected()
            {
                Chats = _chatService.GetUsersChat(await _userManager.GetUserByClaimsIdentityNameAsync(userIdentity)),
                Selected = chat
            };*/
            
            
            var chats = new List<ChatDto>()
            {
                new()
                {
                    Id = 1,
                    ChatName = "Some chat",
                    Messeges = new List<MessegeDto>()
                    {
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend",
                            SentOn = DateTime.Now,
                            Sender = new UserDto()
                            {
                                Name = "Name",
                                Id = "nvirnrk"
                            }
                        },
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3",
                            SentOn = DateTime.Now,
                            Sender = new UserDto()
                            {
                                Name = "Myroslav",
                                Id = "b10b5c7b-6af6-4d0d-b39f-6b858961ed1a"
                            }
                        },new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend3",
                            SentOn = DateTime.Now,
                            Sender = new UserDto()
                            {
                                Name = "Name",
                                LastName = "LastName",
                                Id = "nvirnrk"
                            }
                        }
                    },
                    Participants = new List<UserDto>()
                    {
                        new(),
                        new()
                    }
                },
                new()
                {
                    Id=2,
                    ChatName = "Some chat2",
                    Messeges = new List<MessegeDto>()
                    {
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend",
                            SentOn = DateTime.Now,
                            Sender = new UserDto()
                            {
                                Name = "Name",
                                Id = "nvirnrk"
                            }
                        },
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend2",
                            SentOn = DateTime.Now,
                            Sender = new UserDto()
                            {
                                Name = "Myroslav",
                                Id = "b10b5c7b-6af6-4d0d-b39f-6b858961ed1a"
                            }
                        },new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend3",
                            SentOn = DateTime.Now,
                            Sender = new UserDto()
                            {
                                Name = "Name",
                                LastName = "LastName",
                                Id = "nvirnrk"
                            }
                        }
                    }
                },
                new()
                {
                    Id=3,
                    ChatName = "Some chat3",
                    Messeges = new List<MessegeDto>()
                    {
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend",
                            SentOn = DateTime.Now
                        },
                        new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend2",
                            SentOn = DateTime.Now
                        },new MessegeDto()
                        {
                            Value = "Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3Hello, test messege for you my friend3",
                            SentOn = DateTime.Now
                        },
                    }
                }
            };

            var selected = chats.First(c => c.Id == id);
            
            var response = new ChatsAndSelected()
            {
                Chats = chats,
                Selected = selected
            };
            
            return View(response);
        }
        return Redirect("/");
    }
}