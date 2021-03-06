﻿define([], function () {
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
                    callback("Error while loading student detail.");
                }
            });
        };

        this.Drop = function (studentId, scheduleId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Enrollment/DropEnrolledSchedule?studentId=" + studentId + "&scheduleId=" + scheduleId,
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
                url: "http://localhost:5419/Api/Student/Enroll?id=" + studentId + "&scheduleId=" + scheduleId,
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

        this.RequestChange = function (requestData, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Student/SendStudentRequest",
                data: requestData,
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while requesting a grade change.');
                    callback("Error while requesting a grade change.")
                }
            });
        };

        this.ViewGrade = function (studentId, scheduleId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Student/ViewGrade?id=" + studentId + "&scheduleId=" + scheduleId,
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

        this.EnrollCourse = function (studentId, scheduleId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Enrollment/EnrollSchedule?studentId=" + studentId + "&scheduleId=" + scheduleId,
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

        this.GetEnrolledSchedules = function (id, callback) {
            $.ajax({
                async: asyncIndicator,
                method: 'POST',
                url: "http://localhost:5419/Api/Enrollment/GetEnrolledSchedules?id=" + id,
                data: "",
                dataType: "json",
                success: function (message) {
                    callback(message);
                },
                error: function () {
                    callback('Error while updating studentinfo');
                }
            });
        };

		this.GetRequestHistory = function (id, callback) {
		    $.ajax({
		        async: asyncIndicator,
		        method: 'POST',
		        url: "http://localhost:5419/Api/Student/GetRequestHistory?id=" + id,
		        data: "",
		        dataType: "json",
		        success: function (message) {
		            callback(message);
		        },
		        error: function () {
		            callback('Error while loading request history');
		        }
		    });
		};

        this.InstructorCourses = function (id, callback) {
            $.ajax({
                async: asyncIndicator,
                method: 'POST',
                url: "http://localhost:5419/Api/Enrollment/InstructorCourses?id=" + id,
                data: "",
                dataType: "json",
                success: function (message) {
                    callback(message);
                },
                error: function () {
                    callback('Error while loading courses');
                }
            });
        };
    }

    this.GetYears = function (callback) {
        $.ajax({
            method: 'GET',
            url: "http://localhost:5419/Api/Schedule/GetYears",
            data: "",
            dataType: "json",
            success: function (result) {
                // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                // See AdminViewModel.load and see how it's being used
                callback(result); // "that" is currently pointing to the AdminModel object
            },
            error: function () {
                // if the call fails, it will return FirstName="First" and LastName="Last"
                alert('Error while loading years');
                callback("Error while loading years");
            }
        });
    };

    this.GetQuarters = function (callback) {
        $.ajax({
            method: 'GET',
            url: "http://localhost:5419/Api/Schedule/GetQuarters",
            data: "",
            dataType: "json",
            success: function (result) {
                // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                // See AdminViewModel.load and see how it's being used
                callback(result); // "that" is currently pointing to the AdminModel object
            },
            error: function () {
                // if the call fails, it will return FirstName="First" and LastName="Last"
                alert('Error while loading quarters');
                callback("Error while loading quarters");
            }
        });
    };

    this.FilterGetSchedule = function (year, quarter, callback) {
        $.ajax({
            method: 'POST',
            url: "http://localhost:5419/Api/Schedule/GetScheduleList?year=" + year + "&quarter=" + quarter,
            data: "",
            dataType: "json",
            success: function (result) {
                // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                // See AdminViewModel.load and see how it's being used
                callback(result); // "that" is currently pointing to the AdminModel object
            },
            error: function () {
                // if the call fails, it will return FirstName="First" and LastName="Last"
                alert('Error while loading schedules.');
                callback("Error while loading schedules");
            }
        });
    };

    return StudentModel;
});