using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Context;
using todo_serverside.DTOs;
using todo_serverside.Photos;

namespace todo_serverside.Handlers
{
    public class AccountSetAvatarHandler : IRequestHandler<AccountSetAvatarCommand, string>
    {
        public AccountSetAvatarHandler(TodoListContext context, IPhotoAccessor photoAccessor)
        {
            _context = context;
            _photoAccessor = photoAccessor;
        }

        private TodoListContext _context { get; set; }
        private  IPhotoAccessor _photoAccessor { get; set; }
        

        
        public async  Task<string> Handle(AccountSetAvatarCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId.ToString());

            var photoUploadResult = await _photoAccessor.AddPhoto(request.Avatar);
            user.Avatar = photoUploadResult.Url;
            await _context.SaveChangesAsync();
            return user.Avatar;
        }
    }
}
