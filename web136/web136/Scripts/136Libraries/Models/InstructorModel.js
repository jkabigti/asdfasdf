define([], function () {
    $.support.cors = true;
    function InstructorModel() {

        this.EditGrade = function (scheduleId, studentId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Instructor/EditGrade?scheduleId=" + scheduleId + "&studentId=" + studentId,
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while editing grade.');
                    callback("Error while editing grade");
                }
            });
        };

        this.GetRequests = function (scheduleId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Instructor/GetRequests?scheduleId=" + scheduleId,
                data: "", // note, adminData must be the same as PLAdmin for this to work correctly
                dataType: "json",
                success: function (message) {
                    callback(message);
                },
                error: function () {
                    callback('Error while getting requests');
                }
            });

        };

        this.DropStudent = function (scheduleId, studentId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Instructor/DropStudent?scheduleId=" + scheduleId + "&studentId=" + studentId,
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while dropping student');
                    callback("Error while dropping student");
                }
            });
        };

        this.AddTutor = function (tutorId, courseId, firstName, lastName, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Instructor/AddTutor?tutorId=" + tutorId + "&courseId=" + courseId
                + "&firstName=" + firstName + "&lastName=" + lastName,
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while adding tutor');
                    callback("Error while adding tutor");
                }
            });
        };

        this.AssignTutor = function (tutorId, courseId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Instructor/AssignTutor?tutorId=" + tutorId + "&courseId=" + courseId,
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while assigning tutor');
                    callback("Error while assigning tutor");
                }
            });
        };

        this.DeleteTutor = function (tutorId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Instructor/DeleteTutor?tutorId=" + tutorId,
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while deleting tutor');
                    callback("Error while deleting tutor");
                }
            });
        };

        this.GetInstructorCourse = function (instructorId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Instructor/GetInstructorCourse?instructorId=" + instructorId,
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while getting instructor\'s courses');
                    callback("Error while getting instructor's courses");
                }
            });
        };

    }

    return InstructorModel;
});