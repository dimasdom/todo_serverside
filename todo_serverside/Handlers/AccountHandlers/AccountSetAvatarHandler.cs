using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Context;
using todo_serverside.Models;
using todo_serverside.Photos;

namespace todo_serverside.Handlers
{
    public class AccountSetAvatarHandler : IRequestHandler<AccountSetAvatarCommand, string>
    {


        public AccountSetAvatarHandler(TodoListContext context, IPhotoAccessor photoAccessor, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _photoAccessor = photoAccessor;
            UserManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        private readonly IHttpContextAccessor _httpContextAccessor;
        private TodoListContext _context { get; set; }
        private IPhotoAccessor _photoAccessor { get; set; }
        public UserManager<User> UserManager { get; }

        public async Task<string> Handle(AccountSetAvatarCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await _context.Users.FindAsync(currentUserId);
            var photoUploadResult = await _photoAccessor.AddPhoto(request.Avatar);
            user.Avatar = photoUploadResult.Url;
            await _context.SaveChangesAsync();
            return user.Avatar;
        }
    }
}
