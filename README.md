========================================================================================================================
                                            PROJECT ARCHITECTURE 
========================================================================================================================



WeddingHallBookingSystem
│
├── WeddingHall.Domain
│   ├── BaseDomainClass.cs
│   ├── HallMaster.cs
│   ├── SubHallDetail.cs
│   ├── Users.cs
│   ├── Role.cs
│   ├── City.cs
│   ├── District.cs
│   └── (Other domain entities)
│
├── WeddingHall.Application
│   ├── DTOs
│   │   ├── Hall
│   │   │   ├── HallCreateRequest.cs
│   │   │   ├── HallUpdateRequest.cs
│   │   │   └── HallResponse.cs
│   │   ├── SubHall
│   │   │   ├── SubHallCreateRequest.cs
│   │   │   ├── SubHallUpdateRequest.cs
│   │   │   └── SubHallResponse.cs
│   │   ├── UserRegistration
│   │   └── SignIn
│   │
│   ├── Interfaces
│   │   ├── IUserService.cs
│   │   ├── IHallService.cs
│   │   ├── ISubHallService.cs
│   │   └── Repositories
│   │       ├── IGenericRepository.cs
│   │       └── IHallRepository.cs (if added for Includes)
│
├── WeddingHall.Infrastructure
│   ├── ApplicationDbContext.cs
│   │
│   ├── Repositories
│   │   ├── GenericRepository.cs
│   │   └── HallRepository.cs (for City/District Include logic)
│   │
│   ├── Services
│   │   ├── UserService.cs
│   │   ├── HallService.cs
│   │   └── SubHallService.cs
│
├── WeddingHall.API
│   ├── Controllers
│   │   ├── UserController.cs
│   │   ├── HallController.cs
│   │   └── SubHallController.cs
│   │
│   ├── Program.cs
│   └── appsettings.json
