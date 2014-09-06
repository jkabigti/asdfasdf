// AdminViewModel depends on the Models/AdminModel to process requests (Load, Update)
define(['Models/AdminModel'], function (adminModel) {
    function AdminViewModel() {
        var self = this;
        var scheduleListViewModel = ko.observableArray();
        var initialBind = true;

        this.Load = function (id) {
            var adminModelObj = new adminModel();

            // Because the Load() is a async call (asynchronous), we'll need to use
            // the callback approach to handle the data after data is loaded.
            adminModelObj.Load(id, function (result) {

                var viewModel = {
                    first: ko.observable(result.FirstName),
                    last: ko.observable(result.LastName),
                    email: ko.observable(result.Email),
                    password: ko.observable(result.Password),
                    id: result.Id,
                    update: function() {
                        self.UpdateAdmin(this);
                    }
                }

                ko.applyBindings(viewModel , document.getElementById("divAdminEdit"));
            });
        };

        this.UpdateAdmin = function (viewModel) {
            var adminModelObj = new adminModel();

            // convert the viewModel to same structure as PLAdmin model (presentation layer model)
            var adminData = {
                Id: viewModel.id,
                FirstName: viewModel.first(),
                LastName: viewModel.last(),
                Email: viewModel.email(),
                Password: viewModel.password()
            };

            adminModelObj.Update(adminData, function (message) {
                $('#divMessage').html(message);
            });

        };
        
        this.GetAllSchedules = function () {
            var adminModelObj = new adminModel();
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
            var adminModelObj = new adminModel();
            var yearListViewModel = ko.observableArray();
            adminModelObj.GetYears(function (yearList) {
                yearListViewModel.removeAll();
                yearListViewModel.push({year: "All Years"});
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
            var adminModelObj = new adminModel();
            adminModelObj.FilterGetSchedule(year, quarter, function (scheduleList) {
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

        this.ApplyFilter = function () {
            var adminModelObj = new adminModel();
            var year = document.getElementById("yearListContent").value.toString();
            var quarter = document.getElementById("quarterListContent").value.toString();
            adminModelObj.FilterGetSchedule(year, quarter, function (scheduleList) {
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
            });
        }

        this.LoadScheduleInfo = function () {
            var adminModelObj = new adminModel();
            var id = window.location.search.substring(4);
            adminModelObj.GetScheduleInfo(id, function (courseInfo) {
                var viewModel = {
                    year: courseInfo.Year,
                    quarter: courseInfo.Quarter,
                    session: courseInfo.Session,
                    course_title: courseInfo.CourseTitle,
                    course_description: courseInfo.CourseDescription,
                    course_id: courseInfo.CourseId,
                    schedule_id: courseInfo.scheduleId,
                    update: function () {
                        self.EditSchedule(this);
                    }
                };
                ko.applyBindings(viewModel, document.getElementById("divScheduleEdit"));
            });
        }

        this.EditSchedule = function (viewModel) {
            alert("Update Schedule in Model");
            //var adminModelObj = new adminModel();
            //var scheduleData = {
            //    Year: viewModel.year,
            //    Quarter: viewModel.quarter(),
            //    Session: viewModel.session(),
            //    CourseTitle: viewModel.course_title(),
            //    CourseDescription: viewModel.course_description(),
            //    CourseId: viewModel.course_id(),
            //    ScheduleId: viewModel.schedule_id()
            //};
            //adminModelObj.UpdateSchedule(scheduleData, function (message) {
            //    //$('#divEditMessage').html(message);
            //});
        };

        this.LoadAnnouncements = function () {
            var adminModelObj = new adminModel();
            var announcementViewModel = ko.observableArray();
            adminModelObj.GetAnnouncements(function (announcementList) {
                announcementViewModel.removeAll();
                for (var i = 0; i < announcementList.length; i++) {
                    announcementViewModel.push({
                        text: announcementList[i].Text,
                        date: announcementList[i].Date,
                        id: announcementList[i].ID
                    });
                }

                if (initialBind) {
                    ko.applyBindings({ viewModel: announcementViewModel }, document.getElementById("divAnnouncementContent"));
                    initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
                }
            });
        };

        this.GetAnnouncementById = function () {
            var adminModelObj = new adminModel();
            var announcement_id = window.location.search.substring(4);
            adminModelObj.GetAnnouncementById(announcement_id, function (announcement) {
                
                var announcementViewModel = {
                    id: announcement.ID,
                    text: announcement.Text,
                    date: announcement.Date
                };
                //alert(announcement.Text);
                ko.applyBindings(announcementViewModel, document.getElementById("divAnnouncementEdit"));
            });
        };
    }
    return AdminViewModel;
}
);