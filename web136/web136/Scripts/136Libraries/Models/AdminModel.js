﻿
define([], function () {
    $.support.cors = true;
    function AdminModel() {

        this.Load = function (adminId, callback) {
            $.ajax({
                method: 'GET',
                url: "http://localhost:5419/Api/Admin/GetAdminInfo?adminId=" + adminId,
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while loading admin info.');
                    callback("Error while loading admin info");
                }
            });
        };

        this.Update = function (adminData, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Admin/UpdateAdminInfo",
                data: adminData, // note, adminData must be the same as PLAdmin for this to work correctly
                success: function (message) {
                    callback(message);
                },
                error: function () {
                    callback('Error while updating admin info');
                }
            });

        };

        this.GetSchedules = function (callback) {
            $.ajax({
                method: 'GET',
                url: "http://localhost:5419/Api/Schedule/GetAllSchedules",
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while loading schedules');
                    callback("Error while loading schedules");
                }
            });
        };

        this.AddSchedule = function (schedule, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Schedule/AddSchedule",
                data: schedule,
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while adding schedule');
                    callback("Error while adding schedule");
                }
            });
        };

        this.EditSchedule = function (schedule, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Schedule/EditSchedule",
                data: schedule,
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while updating schedule');
                    callback("Error while updating schedule");
                }
            });
        };

        this.DeleteSchedule = function (id, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Schedule/DeleteSchedule?id=" + id,
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while deleting schedule');
                    callback("Error while deleting schedule");
                }
            });
        };

        this.GetAnnouncements = function (callback) {
            $.ajax({
                method: 'GET',
                url: "http://localhost:5419/Api/Announcement/GetAnnouncements",
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while loading announcements');
                    callback("Error while loading announcements");
                }
            });
        };

        this.AddAnnouncement = function (announcement, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Announcement/AddAnnouncement",
                data: announcement,
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while adding announcement');
                    callback("Error while adding announcement");
                }
            });
        };

        this.EditAnnouncement = function (announcement, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Announcement/EditAnnouncement",
                data: announcement,
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while updating announcement');
                    callback("Error while updating announcement");
                }
            });
        };

        this.GetAnnouncementById = function (id, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Announcement/GetAnnouncementById?id=" + id,
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while getting announcement');
                    callback("Error while getting announcement");
                }
            });
        };

        this.DeleteAnnouncement = function (id, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Announcement/DeleteAnnouncement?id=" + id,
                data: "",
                dataType: "json",
                success: function (result) {
                    // when ajax call recevies data, it'll call the function "callback" which is passed in this as a parameter.
                    // See AdminViewModel.load and see how it's being used
                    callback(result); // "that" is currently pointing to the AdminModel object
                },
                error: function () {
                    // if the call fails, it will return FirstName="First" and LastName="Last"
                    alert('Error while deleting announcement');
                    callback("Error while deleting announcement");
                }
            });
        };

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

        this.GetScheduleInfo = function (scheduleId, callback) {
            $.ajax({
                method: 'POST',
                url: "http://localhost:5419/Api/Schedule/GetScheduleInfo?scheduleId=" + scheduleId,
                data: "",
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while loading schedule info.');
                    callback("Error while loading schedule info");
                }
            });
        }
    }

    return AdminModel;
});