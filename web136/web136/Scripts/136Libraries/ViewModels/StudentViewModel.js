// StudentViewModel depends on the Models/StudentModel to process requests (Load)
define(['Models/StudentModel'], function (StudentModel) {
    function StudentViewModel() {

        var StudentModelObj = new StudentModel();
        var that = this;
        var initialBind = true;
        var studentListViewModel = ko.observableArray();

        this.Initialize = function() {

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

        this.Load = function (id) {
            var studentModelObj = new StudentModel();
            studentModelObj.Load(id, function (result) {

                var viewModel = {
                    id: result.Id,
                    ssn: ko.observable(result.SSN),
                    first: ko.observable(result.FirstName),
                    last: ko.observable(result.LastName),
                    email: ko.observable(result.Email),
                    shoesize: ko.observable(result.ShoeSize),
                    weight: ko.observable(result.Weight),
                    update: function () {
                        self.UpdateStudent(this);
                    }
                }

                ko.applyBindings(viewModel, document.getElementById("divEditStudentRecord"));
            });
        };

        this.CreateStudent = function(data) {
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

            StudentModelObj.Create(model, function(result) {
                if (result == "ok") {
                    alert("Create student successful");
                } else {
                    alert("Error occurred");
                }
            });

        };

        this.GetAll = function() {

            StudentModelObj.GetAll(function(studentList) {
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

        this.UpdateStudent = function (viewModel) {
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

            studentModelObj.UpdateStudent(studentData, function (message) {
                $('#divEditMessage').html(message);
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

        ko.bindingHandlers.DeleteStudent = {
            init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                $(element).click(function () {
                    var id = viewModel.id;

                    StudentModelObj.Delete(id, function(result) {
                        if (result != "ok") {
                            alert("Error occurred");
                        } else {
                            studentListViewModel.remove(viewModel);
                        }
                    });
                });
            }
        }
    }

    return StudentViewModel;
}
);