using Entity_Framework;
using homeWork.Entities;
using Entity_Framework.Repositories;
using Entity_Framework.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var _db = new DBContext();

// add-migration NameMigration -- создание миграции
// update-database -migration:InitialCreate -- обновление до конкретной миграции


var courseService = new CourseServices(_db);
var teacherService = new TeacherServices(_db);
var reviewService = new ReviewRepository(_db);
var studentService = new StudentServices(_db);


while (true)
{
    Console.WriteLine("Выберете действие:" +
        "1) Добавить запись" +
        "2) Удалить запись" +
        "3) Обновить запись" +
        "4) Получить запись");


    var numberOfAction = Console.ReadLine();
    switch (numberOfAction)
    {
        case "1":
            Console.WriteLine("Выберете действие:" +
        "1) Добавить курс" +
        "2) Добавить преподавателя" +
        "3) Добавить студента" +
        "4) Добавить отзыв");

            var numberOfAdd = Console.ReadLine();
            switch (numberOfAdd)
            {
                case "1":
                    Console.WriteLine("Введите название курса");
                    string nameOfCourse = Console.ReadLine();

                    Console.WriteLine("Введите описание курса");
                    string description = Console.ReadLine();

                    Console.WriteLine("Введите кол-во часов");
                    int durationHours = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите сумму курса");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Course course = new Course()
                    {
                        Name = nameOfCourse,
                        Description = description,
                        DurationHours = durationHours,
                        Price = price
                    };

                    await courseService.AddAsync(course);
                    break;



                case "2":
                    Console.WriteLine("Введите имя сотрудника");
                    string firstNameofInstructor = Console.ReadLine();

                    Console.WriteLine("Введите фамилию сотрудника");
                    string lastNameofInstructor = Console.ReadLine();

                    Console.WriteLine("Введите отчество сотрудника");
                    string patronymicOfInstructor = Console.ReadLine();

                    Console.WriteLine("Введите почту");
                    string emailOfInstructor = Console.ReadLine();

                    Console.WriteLine("Введите зарплату");
                    string phone = Console.ReadLine();

                    Teacher teacher = new Teacher()
                    {
                        FirstName = firstNameofInstructor,
                        LastName = lastNameofInstructor,
                        Patronymic = patronymicOfInstructor,
                        Email = emailOfInstructor,
                        Phone = phone

                    };
                    await teacherService.AddAsync(teacher);
                    break;

                case "3":
                    Console.WriteLine("Введите id курса");
                    int courseId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите id студента");
                    int studentId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите рейтинг");
                    int rating = int.Parse(Console.ReadLine());

                    Review review = new Review()
                    {
                        CourseID = courseId,
                        StudentID = studentId,
                        Rating = rating

                    };
                    await reviewService.AddAsync(review);
                    break;


                case "4":
                    Console.WriteLine("Введите имя сотрудника");
                    string firstNameofIStudent = Console.ReadLine();

                    Console.WriteLine("Введите фамилию сотрудника");
                    string lastNameofStudent = Console.ReadLine();

                    Console.WriteLine("Введите отчество сотрудника");
                    string patronymicOfStudent = Console.ReadLine();

                    Console.WriteLine("Введите почту");
                    string emailOfStudent = Console.ReadLine();

                    Console.WriteLine("Введите время");
                    DateTime enrollmentDate = DateTime.Now;

                    Student student = new Student()
                    {
                        FirstName = firstNameofIStudent,
                        LastName = lastNameofStudent,
                        Patronymic = patronymicOfStudent,
                        Email = emailOfStudent,
                        EnrollmentDate = enrollmentDate

                    };
                    await studentService.AddAsync(student);
                    break;


            }
            break;


        case "2":
            Console.WriteLine("Выберете действие:" +
        "1) Удалить курс" +
        "2) Удалить преподавателя" +
        "3) Удалить студента" +
        "4) Удалить отзыв");


            var numberOfRemove = Console.ReadLine();
            switch (numberOfRemove)
            {
                case "1":
                    Console.WriteLine("Введите название должности");
                    string nameOfCourse = Console.ReadLine();

                    courseService.GetByNameAsync(nameOfCourse);
                    Course course = new Course()
                    {
                        Name = nameOfCourse
                    };
                    await courseService.RemoveAsync(course);
                    break;



                case "2":
                    Console.WriteLine("Введите фамилию сотрудника");
                    string lastNameofInstructor = Console.ReadLine();


                    Teacher teacher = new Teacher()
                    {
                        LastName = lastNameofInstructor,

                    };
                    await teacherService.RemoveAsync(teacher);
                    break;

                case "3":
                    Console.WriteLine("Введите фамилию сотрудника");
                    string lastNameofStudent = Console.ReadLine();


                    Student student = new Student()
                    {
                        LastName = lastNameofStudent,

                    };
                    await studentService.RemoveAsync(student);
                    break;

                case "4":
                    Console.WriteLine("Введите id студента");
                    int studentID = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите id курса");
                    int courseID = int.Parse(Console.ReadLine());

                    Review review = new Review()
                    {
                        StudentID = studentID,
                        CourseID = courseID

                    };
                    await reviewService.AddAsync(review);
                    break;
            }
            break;

        case "3":
            Console.WriteLine("Выберете действие:" +
        "1) Изменить курс" +
        "2) Изменить преподавателя" +
        "3) Изменить студента" +
        "4) Изменить отзыв");


            var numberOfUpdate = Console.ReadLine();
            switch (numberOfUpdate)
            {
                case "1":
                    Console.WriteLine("Введите название курса");
                    string nameOfCourse = Console.ReadLine();

                    Console.WriteLine("Введите описание курса");
                    string description = Console.ReadLine();

                    Console.WriteLine("Введите кол-во часов");
                    int durationHours = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите сумму курса");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Course course = new Course()
                    {
                        Name = nameOfCourse,
                        Description = description,
                        DurationHours = durationHours,
                        Price = price
                    };

                    await courseService.UpdateAsync(course);
                    break;



                case "2":
                    Console.WriteLine("Введите имя сотрудника");
                    string firstNameofInstructor = Console.ReadLine();

                    Console.WriteLine("Введите фамилию сотрудника");
                    string lastNameofInstructor = Console.ReadLine();

                    Console.WriteLine("Введите отчество сотрудника");
                    string patronymicOfInstructor = Console.ReadLine();

                    Console.WriteLine("Введите почту");
                    string emailOfInstructor = Console.ReadLine();

                    Console.WriteLine("Введите зарплату");
                    string phone = Console.ReadLine();

                    Teacher teacher = new Teacher()
                    {
                        FirstName = firstNameofInstructor,
                        LastName = lastNameofInstructor,
                        Patronymic = patronymicOfInstructor,
                        Email = emailOfInstructor,
                        Phone = phone

                    };
                    await teacherService.UpdateAsync(teacher);
                    break;

                case "3":
                    Console.WriteLine("Введите id курса");
                    int courseId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите id студента");
                    int studentId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите рейтинг");
                    int rating = int.Parse(Console.ReadLine());

                    Review review = new Review()
                    {
                        CourseID = courseId,
                        StudentID = studentId,
                        Rating = rating

                    };
                    await reviewService.UpdateAsync(review);
                    break;


                case "4":
                    Console.WriteLine("Введите имя сотрудника");
                    string firstNameofIStudent = Console.ReadLine();

                    Console.WriteLine("Введите фамилию сотрудника");
                    string lastNameofStudent = Console.ReadLine();

                    Console.WriteLine("Введите отчество сотрудника");
                    string patronymicOfStudent = Console.ReadLine();

                    Console.WriteLine("Введите почту");
                    string emailOfStudent = Console.ReadLine();

                    Console.WriteLine("Введите время");
                    DateTime enrollmentDate = DateTime.Now;

                    Student student = new Student()
                    {
                        FirstName = firstNameofIStudent,
                        LastName = lastNameofStudent,
                        Patronymic = patronymicOfStudent,
                        Email = emailOfStudent,
                        EnrollmentDate = enrollmentDate

                    };
                    await studentService.UpdateAsync(student);
                    break;
            }
            break;

        case "4":
            Console.WriteLine("Выберете действие:" +
        "1) Показать курс" +
        "2) Показать преподавателя" +
        "3) Показать студента" +
        "4) Показать отзыв");


            var numberOfShow = Console.ReadLine();
            switch (numberOfShow)
            {
                case "1":
                    await courseService.GetAllAsync();
                    break;

                case "2":

                    await teacherService.GetAllAsync();
                    break;

                case "3":
                    await studentService.GetAllAsync();
                    break;

                case "4":
                    await reviewService.GetAllAsync();
                    break;
            }
            break;

    }
}
