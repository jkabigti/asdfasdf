// StudentViewModel depends on the Models/StudentModel to process requests (Load)
define(['Models/StudentModel'], function (StudentModel) {
    function StudentViewModel() {

        var StudentModelObj = new StudentModel();
        var that = this;
        var initialBind = true;
        var studentListViewModel = ko.observableArray();
		var enrollmentListViewModel = ko.observableArray();

        this.Initialize = function () {

            var viewModel = {
                id: ko.observable("A0000111"),
                ssn: ko.observable("555-55-3333"),
                first: ko.observable("Bruce"),
                last: ko.observable("Wayne"),
                email: ko.observable("bwayne@ucsd.edu"),
                password: ko.observable("password"),
                shoesize: ko.observable("10"),
                weight: ko.observable("160"),
                add: function (data) {
                    that.CreateStudent(data);
                }
            };

            ko.applyBindings(viewModel, document.getElementById("divStudent"));
        };

        this.GetAllSchedules = function () {
            var adminModelObj = new StudentModel();
            var scheduleListViewModel = ko.observableArray();
            adminModelObj.GetSchedules(function (scheduleList) {
                scheduleListViewModel.removeAll();
                for (var i = 0; i < scheduleList.length; i++) {
                    scheduleListViewModel.push({
                        year: scheduleList[i].Year,
                        quarter: scheduleList[i].Quarter,
                        session: scheduleList[i].Session,
                        course_title: scheduleList[i].CourseTitle,
                        course_description: scheduleList[i].CourseDescription,
                        course_id: scheduleList[i].CourseId,
                        schedule_id: scheduleList[i].ScheduleId
                    });
                }

                if (initialBind) {
                    ko.applyBindings({ viewModel: scheduleListViewModel }, document.getElementById("divScheduleListContent"));
                    initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
                }
            });
        };

        this.LoadFilters = function () {
            var adminModelObj = new StudentModel();
            var yearListViewModel = ko.observableArray();
            adminModelObj.GetYears(function (yearList) {
                yearListViewModel.removeAll();
                yearListViewModel.push({ year: "All Years" });
                for (var i = 0; i < yearList.length; i++) {
                    yearListViewModel.push({
                        year: yearList[i]
                    });
                }

                ko.applyBindings({ viewModel1: yearListViewModel }, document.getElementById("yearListContent"));
            });
            var quarterListViewModel = ko.observableArray();
            adminModelObj.GetQuarters(function (quarterList) {
                quarterListViewModel.removeAll();
                quarterListViewModel.push({ quarter: "All Quarters" });
                for (var i = 0; i < quarterList.length; i++) {
                    quarterListViewModel.push({
                        quarter: quarterList[i]
                    });
                }

                ko.applyBindings({ viewModel2: quarterListViewModel }, document.getElementById("quarterListContent"));
            });
            var viewModel = {
                filter: function () {
                    self.ApplyFilter(this);
                }
            };
            ko.applyBindings(viewModel, document.getElementById("filterbutton"));
        }

        this.FilterGetSchedule = function (year, quarter) {
            var studentModelObj = new StudentModel();
            studentModelObj.FilterGetSchedule(year, quarter, function (scheduleList) {
                scheduleListViewModel.removeAll();
                for (var i = 0; i < scheduleList.length; i++) {
                    scheduleListViewModel.push({
                        year: scheduleList[i].Year,
                        quarter: scheduleList[i].Quarter,
                        session: scheduleList[i].Session,

                        course_title: scheduleList[i].CourseTitle,
                        course_description: scheduleList[i].CourseDescription,
                        course_id: scheduleList[i].CourseId,
                        schedule_id: scheduleList[i].ScheduleId
                    });
                }
                var node = document.getElementById("divScheduleListContent");
                console.log('test: ', scheduleListViewModel());
                if (initialBind) {
                    ko.applyBindings({ viewModel: scheduleListViewModel }, node);
                }
            });
        };

        this.CreateStudent = function (data) {
            var model = {
                StudentId: data.id(),
                SSN: data.ssn(),
                FirstName: data.first(),
                LastName: data.last(),
                Email: data.email(),
                Password: data.password(),
                ShoeSize: data.shoesize(),
                Weight: data.weight()
            }

            StudentModelObj.Create(model, function (result) {
                if (result == "ok") {
                    alert("Create student successful");
                } else {
                    alert("Error occurred");
                }
            });

        };

        this.GetAll = function () {

            StudentModelObj.GetAll(function (studentList) {
                studentListViewModel.removeAll();

                for (var i = 0; i < studentList.length; i++) {
                    studentListViewModel.push({
                        id: studentList[i].StudentId,
                        first: studentList[i].FirstName,
                        last: studentList[i].LastName,
                        email: studentList[i].Email
                    });
                }

                if (initialBind) {
                    ko.applyBindings({ viewModel: studentListViewModel }, document.getElementById("divStudentListContent"));
                    initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
                }
            });
        };

        this.StudentEnroll = function (viewModel) {
            var studentModelObj = new StudentModel();

            var studentData = {
                StudentId: viewModel.id(),
                SSN: viewModel.ssn(),
                FirstName: viewModel.first(),
                LastName: viewModel.last(),
                Email: viewModel.email(),
                Password: viewModel.password(),
                ShoeSize: viewModel.shoesize(),
                Weight: viewModel.weight()
            };

            studentModelObj.StudentEnroll(studentData, function (message) {
                $('#divEditMessage').html(message);
            });
        };

        this.GetEnrolledSchedules = function (id) {
            var studentModelObj = new StudentModel();
		    studentModelObj.GetEnrolledSchedules(id, function (enrollmentList) {
		        enrollmentListViewModel.removeAll();
				for (var i = 0; i < enrollmentList.length; i++) {
				    enrollmentListViewModel.push({
                        id: enrollmentList[i].StudentId,
						year: ko.observable(enrollmentList[i].Year),
						quarter: ko.observable(enrollmentList[i].Quarter),
						session: ko.observable(enrollmentList[i].Session),
						course_title: ko.observable(enrollmentList[i].CourseTitle),
						course_description: ko.observable(enrollmentList[i].CourseDescription),
						course_id: ko.observable(enrollmentList[i].CourseId),
                        grade: ko.observable(enrollmentList[i].Grade),
                        schedule_id: ko.observable(enrollmentList[i].ScheduleId),
                        drop: function () {
                            that.DropCourse(this);
                        }
					});
				}
				var node = document.getElementById("divEnrollmentListContent");
				//console.log('test: ', JSON.stringify(enrollmentListViewModel()));

				if (initialBind) {
				    ko.applyBindings({ viewModel: enrollmentListViewModel }, document.getElementById("divEnrollmentListContent"));
				}
			});
		};

        this.GetDetail = function (id) {

            StudentModelObj.GetDetail(id, function (result) {

                var student = {
                    id: result.StudentId,
                    first: result.FirstName,
                    last: result.LastName,
                    email: result.Email,
                    shoesize: result.ShoeSize,
                    weight: result.Weight,
                    ssn: result.SSN
                };

                if (initialBind) {
                    ko.applyBindings({ viewModel: student }, document.getElementById("divStudentContent"));
                }
            });
        };

        this.Load = function (id) {

            StudentModelObj.GetDetail(id, function (result) {
                var viewModel = {
                    id: result.StudentId,
                    first: ko.observable(result.FirstName),
                    last: ko.observable(result.LastName),
                    email: ko.observable(result.Email),
                    password: ko.observable(result.Password),
                    shoesize: ko.observable(result.ShoeSize),
                    weight: ko.observable(result.Weight),
                    ssn: ko.observable(result.SSN),
                    update: function () {
                        that.UpdateStudent(this);
                    }              
                }
                ko.applyBindings(viewModel, document.getElementById("divEditStudentRecord"));
            });
        };

        this.UpdateStudent = function (viewModel) {
            var studentModelObj = new StudentModel();
            var studentData = {
                StudentId: viewModel.id,
                FirstName: viewModel.first(),
                LastName: viewModel.last(),
                Email: viewModel.email(),
                Password: viewModel.password(),
                ShoeSize: viewModel.shoesize(),
                Weight: viewModel.weight(),
                SSN: viewModel.ssn()
            };
            studentModelObj.UpdateStudent(studentData, function (message) {
                $('#divEditMessage').html(message);
            });
        };

        ko.bindingHandlers.DeleteStudent = {
            init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                $(element).click(function () {
                    var id = viewModel.id;

                    StudentModelObj.Delete(id, function (result) {
                        if (result != "ok") {
                            alert("Error occurred");
                        } else {
                            studentListViewModel.remove(viewModel);
                        }
                    });
                });
            }
        }

        this.EnrollCourse = function (viewModel) {
            var studentModelObj = new StudentModel();
<<<<<<< HEAD
            var studentId = window.location.search.substring(4,11);
=======
            var studentId = window.location.search.substring(4, 11);
>>>>>>> origin/master
            var scheduleId = window.location.search.substring(23);
            studentModelObj.Enroll(studentId, scheduleId, function (message) {
                $('#divAddMessage').html(message);
            });
<<<<<<< HEAD
        }
=======
        };

        this.DropCourse = function (viewModel) {
            var studentModelObj = new StudentModel();
            var studentId = window.location.search.substring(4);
            var scheduleId = viewModel.schedule_id();
            studentModelObj.Drop(studentId, scheduleId, function (message) {
                $('#divAddMessage').html(message);
            })
        };
>>>>>>> origin/master
    }

    return StudentViewModel;
}
);