using challengeN5.Data.interfaces;
using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.commands;
using challengeN5.Data.relational.common;
using challengeN5.Data.relational.handlers;
using challengeN5.Data.relational.queries;
using challengeN5.Data.relational.repositories;
using challengeN5.Models;
using Moq;
using Nest;
using Shouldly;

namespace challengeN5.Tests
{
    public class PermissionControllerTests
    {
        private readonly Mock<IPermissionRepository> _permissionRepositoryMock;
        private readonly Mock<IPermissionTypeRepository> _permissionTypeRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public PermissionControllerTests()
        {
            _permissionRepositoryMock = new();//new Mock<IPermissionRepository>();
            _permissionTypeRepositoryMock = new();
            _unitOfWorkMock = new();
        }

        [Fact]
        public async Task CreateShouldBeSuccessfully()
        {
            // Arrange

            _permissionTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PermissionType()
                {
                    Id = 1,
                    Description = "Super Admin"
                });

            var unitOfWork = new UnitOfWorkBehavior<CreatePermissionCommand, Permission>(_unitOfWorkMock.Object);

            var command = new CreatePermissionCommand("Damian", "Gluk", DateTime.Now, 1);
            var handler = new CreatePermissionHandler(_permissionRepositoryMock.Object, _permissionTypeRepositoryMock.Object);

            // Act

            var result = await unitOfWork.Handle(command, async () => await handler.Handle(command, default), default);

            // Asserts

            result.ShouldBeOfType<Permission>();
            result.EmployeeName.ShouldBe("Damian");
            result.EmployeeSurname.ShouldBe("Gluk");
            result.PermissionDate.ShouldBe(DateTime.Now, tolerance: TimeSpan.FromSeconds(1));
            result.PermissionTypeId.ShouldBe(1);
            result.PermissionType.ShouldBeOfType<PermissionType>();
            result.PermissionType.Id.ShouldBe(1);
            result.PermissionType.Description.ShouldBe("Super Admin");
        }

        [Fact]
        public async Task CreateShouldBeFailure()
        {
            // Arrange
            
            _permissionTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((int id, CancellationToken token) => null);

            var unitOfWork = new UnitOfWorkBehavior<CreatePermissionCommand, Permission>(_unitOfWorkMock.Object);

            var command = new CreatePermissionCommand("Damian", "Gluk", DateTime.Now, 1);
            var handler = new CreatePermissionHandler(_permissionRepositoryMock.Object, _permissionTypeRepositoryMock.Object);

            // Act

            var result = await unitOfWork.Handle(command, async () => await handler.Handle(command, default), default);

            // Asserts

            result.ShouldBeNull();
        }

        [Fact]
        public async Task UpdateShouldBeSuccesfully()
        {
            // Arrange

            _permissionTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PermissionType()
                {
                    Id = 1,
                    Description = "Super Admin"
                });

            _permissionRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new Permission()
               {
                   Id = 1,
                   EmployeeName = "Damian2",
                   EmployeeSurname = "Gluk2",
                   PermissionDate = new DateTime(2023, 12, 29),
                   PermissionTypeId = 3,
                   PermissionType = new PermissionType()
                   {
                       Id = 3,
                       Description = "Moderator"
                   }
               });

            var unitOfWork = new UnitOfWorkBehavior<UpdatePermissionCommand, Permission>(_unitOfWorkMock.Object);

            var command = new UpdatePermissionCommand(1, "Damian", "Gluk", DateTime.Now, 1);
            var handler = new UpdatePermissionHandler(_permissionRepositoryMock.Object, _permissionTypeRepositoryMock.Object);

            // Act

            var result = await unitOfWork.Handle(command, async () => await handler.Handle(command, default), default);

            // Asserts

            result.ShouldBeOfType<Permission>();
            result.Id.ShouldBe(1);
            result.EmployeeName.ShouldBe("Damian");
            result.EmployeeSurname.ShouldBe("Gluk");
            result.PermissionDate.ShouldBe(DateTime.Now, tolerance: TimeSpan.FromSeconds(1));
            result.PermissionTypeId.ShouldBe(1);
            result.PermissionType.ShouldBeOfType<PermissionType>();
            result.PermissionType.Id.ShouldBe(1);
            result.PermissionType.Description.ShouldBe("Super Admin");
        }

        [Fact]
        public async Task UpdateShouldBePemissionNotFoundFailure()
        {
            // Arrange

            _permissionTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PermissionType()
                {
                    Id = 1,
                    Description = "Super Admin"
                });

            _permissionRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync((int id, CancellationToken token) => null);

            var unitOfWork = new UnitOfWorkBehavior<UpdatePermissionCommand, Permission>(_unitOfWorkMock.Object);

            var command = new UpdatePermissionCommand(1, "Damian", "Gluk", DateTime.Now, 1);
            var handler = new UpdatePermissionHandler(_permissionRepositoryMock.Object, _permissionTypeRepositoryMock.Object);

            // Act

            var result = await unitOfWork.Handle(command, async () => await handler.Handle(command, default), default);

            // Asserts

            result.ShouldBeNull();
        }

        [Fact]
        public async Task UpdateShouldBePemissionTypeNotFoundFailure()
        {
            // Arrange

            _permissionTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((int id, CancellationToken token) => null);

            _permissionRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new Permission()
               {
                   Id = 1,
                   EmployeeName = "Damian2",
                   EmployeeSurname = "Gluk2",
                   PermissionDate = new DateTime(2023, 12, 29),
                   PermissionTypeId = 3,
                   PermissionType = new PermissionType()
                   {
                       Id = 3,
                       Description = "Moderator"
                   }
               });

            var unitOfWork = new UnitOfWorkBehavior<UpdatePermissionCommand, Permission>(_unitOfWorkMock.Object);

            var command = new UpdatePermissionCommand(1, "Damian", "Gluk", DateTime.Now, 1);
            var handler = new UpdatePermissionHandler(_permissionRepositoryMock.Object, _permissionTypeRepositoryMock.Object);

            // Act

            var result = await unitOfWork.Handle(command, async () => await handler.Handle(command, default), default);

            // Asserts

            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetAllShouldBeSuccesfully()
        {
            // Arrange

            _permissionRepositoryMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
               .ReturnsAsync(new List<Permission>()
               {
                   new Permission() {
                       Id = 1,
                       EmployeeName = "Damian",
                       EmployeeSurname = "Gluk",
                       PermissionDate = new DateTime(2023, 12, 29),
                       PermissionTypeId = 1,
                       PermissionType = new PermissionType()
                       {
                           Id = 1,
                           Description = "Super Admin"
                       }
                   },
                   new Permission() {
                       Id = 2,
                       EmployeeName = "Damian2",
                       EmployeeSurname = "Gluk2",
                       PermissionDate = new DateTime(2023, 12, 30),
                       PermissionTypeId = 3,
                       PermissionType = new PermissionType()
                       {
                           Id = 3,
                           Description = "Moderator"
                       }
                   },
                   new Permission() {
                       Id = 3,
                       EmployeeName = "Damian3",
                       EmployeeSurname = "Gluk3",
                       PermissionDate = new DateTime(2023, 12, 31),
                       PermissionTypeId = 5,
                       PermissionType = new PermissionType()
                       {
                           Id = 5,
                           Description = "Client"
                       }
                   }

               });

            var unitOfWork = new UnitOfWorkBehavior<GetAllPermissionQuery, IEnumerable<Permission>>(_unitOfWorkMock.Object);

            var query = new GetAllPermissionQuery();
            var handler = new GetAllPermissionHandler(_permissionRepositoryMock.Object);

            // Act

            var result = await unitOfWork.Handle(query, async () => await handler.Handle(query, default), default);

            // Asserts

            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<Permission>>();
            result.Count().ShouldBe(3);
        }
    }
}