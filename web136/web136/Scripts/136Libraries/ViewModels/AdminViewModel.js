// AdminViewModel depends on the Models/AdminModel to process requests (Load, Update)
define(['Models/AdminModel'], function (adminModel) {
    function AdminViewModel() {
        var self = this;

        this.Load = function (id) {
            var adminModelObj = new adminModel();

            // Because the Load() is a async call (asynchronous), we'll need to use
            // the callback approach to handle the data after data is loaded.
            adminModelObj.Load(id, function (result) {

                var viewModel = {
                    first: ko.observable(result.FirstName),
                    last : ko.observable(result.LastName),
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
                LastName: viewModel.last()
            };

            adminModelObj.Update(adminData, function (message) {
                $('#divMessage').html(message);
            });

        };
        
        this.GetAllSchedule = function () {
            var adminModelObj = new adminModel();
            var scheduleListViewModel = ko.observableArray();

            adminModelObj.GetAll(function (scheduleList) {
                scheduleListViewModel.removeAll();

                for (var i = 0; i < scheduleList.length; i++) {
                    scheduleListViewModel.push({
                        year: scheduleList[i].Year,
                        quarter: scheduleList[i].Quarter,
                        session: scheduleList[i].Session,
                        course_title: scheduleList[i].CourseTitle,
                        course_description: scheduleList[i].CourseDescription,
                        course_id: scheduleList[i].CourseId,
                        schedule_id: scheduleList[i].ScheduleId,
                    });
                }

                if (initialBind) {
                    ko.applyBindings({ viewModel: scheduleListViewModel }, document.getElementById("divScheduleListContent"));
                    initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
                }
            });
        };

    }
    return AdminViewModel;
}
);