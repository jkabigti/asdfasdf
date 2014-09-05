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
    }
    return AdminViewModel;
}
);