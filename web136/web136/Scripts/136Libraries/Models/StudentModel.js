define([], function () {
    $.support.cors = true;
    
    //// THe reason for asyncIndicator is to make sure Jasmine test cases can run without error
    //// Due to async nature of ajax, the Jasmine's compare function would throw an error during
    //// a callback. By allowing this optional paramter for StudentModel function, it forces the ajax
    //// call to be synchronous when running the Jasmine tests.  However, the viewModel will not pass
    //// this parameter so the asynncIndicator would be undefined which is set to "true". Ajax would
    //// be async when called by viewModel.
    function StudentModel(asyncIndicator) {
        if (asyncIndicator == undefined) {
            asyncIndicator = true;
        }

        this.Create = function (student, callback) {
            $.ajax({
                async: asyncIndicator,
                method: "POST",
                url: "http://localhost:5419/Api/Student/InsertStudent",
                data: student,
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while adding student.  Is your service layer running?');
                }
            });
        };

        this.Delete = function (id, callback) {
            $.ajax({
                async: asyncIndicator,
                method: "POST",
                url: "http://localhost:5419/Api/Student/DeleteStudent1" + id,
                data: "",
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while deleteing student.  Is your service layer running?');
                }
            });
        };

        this.GetAll = function (callback) {
            $.ajax({
                async: asyncIndicator,
                method: "GET",
                url: "http://localhost:5419/Api/Student/GetStudentList",
                data: "",
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while loading student list.  Is your service layer running?');
                }
            });
        };

        this.GetDetail = function (id, callback) {
            $.ajax({
                async: asyncIndicator,
                method: "GET",
                url: "http://localhost:5419/Api/Student/GetStudent?id=" + id,
                data: "",
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while loading student detail.  Is your service layer running?');
                }
            });
        };

        this.Drop = function (studentId, scheduleId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Student/Drop?studentId=" + studentId + "&scheduleId=" + scheduleId,
                data: "",
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while dropping course');
                    callback("Error while dropping course");
                }
            });
        };

        this.Enroll = function (studentId, scheduleId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Student/Enroll?studentId" + studentId + "&scheduleId=" + scheduleId,
                data: "",
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while enrolling into the course');
                    callback("Error while enrolling into the course");
                }
            });
        };

        this.ViewGrade = function (studentId, scheduleId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Student/ViewGrade?studentId" + studentId + "&scheduleId=" + scheduleId,
                data: "",
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while viewing the grade');
                    callback("Error while viewing the grade");
                }
            });
        };

        this.AddRequest = function (studentId, scheduleId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Student/AddRequest?studentId" + studentId + "&scheduleId=" + scheduleId,
                data: "",
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while requesting grade change');
                    callback("Error while requesting grade change");
                }
            });
        };

        this.EnrollCourse = function (studentId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Student/EnrollCourse?studentId" + studentId,
                data: "",
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while loading enrolled courses');
                    callback("Error while loading enrolled courses");
                }
            });
        };

        this.UpdateStudent = function (studentData, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Student/UpdateStudent",
                data: studentData,
                success: function (message) {
                    callback(message);
                },
                error: function () {
                    callback('Error while updating student info');
                }
            });
        };

		this.CourseScheduleStudent = function (studentData, callback) {
			$.ajax({
				method: 'POST',
				url: "http://localhost:5419/Api/Student/EnrollCourse?StudentId=" + stdentId,
				data: "",
				success: function (message) {
					callback(message);
				},
				error: function () {
					callback('Eror while updating studentinfo');
				}
			});
		};
    }

    return StudentModel;
});