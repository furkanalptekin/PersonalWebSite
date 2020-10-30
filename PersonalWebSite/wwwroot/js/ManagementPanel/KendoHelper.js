class KendoHelper {

    constructor(controllerName) {
        kendo.culture("tr-TR");
        this.controllerName = controllerName;
    }

    fieldShow() {
        var controllerName = this.controllerName;
        return {
            name: "goster",
            text: "",
            iconClass: "k-icon k-i-select-all m-0",
            click: function (e) {
                e.preventDefault();
                var data = this.dataItem($(e.target).closest("tr"));
                ChangeURL('/' + controllerName + '/Show/', data.Id);
            }
        };
    }

    fieldUpdate() {
        var controllerName = this.controllerName;
        return {
            name: "guncelle",
            text: "",
            iconClass: "k-icon k-i-edit m-0",
            click: function (e) {
                e.preventDefault();
                var data = this.dataItem($(e.target).closest("tr"));
                ChangeURL('/' + controllerName + '/Update/', data.Id);
            }
        };
    }

    fieldDelete() {
        var controllerName = this.controllerName;
        return {
            name: "sil",
            text: "",
            iconClass: "k-icon k-i-delete m-0",
            click: function (e) {
                e.preventDefault();
                var tr = $(e.target).closest("tr");
                var data = this.dataItem(tr);
                Delete('/' + controllerName + '/Delete/', data.Id, tr);
            }
        };
    }

    createGrid(gridName, columns) {
        $("#" + gridName).kendoGrid({
            dataSource: {
                type: "odata",
                transport: {
                    read: this.getGridData(gridName)
                },
                pageSize: 15,
            },
            mobile: true,
            autoSync: true,
            batch: true,
            height: "76vh",
            groupable: true,
            sortable: true,
            scrollable: false,
            columns: columns
        });
    }

    getGridData(gridName) {
        var grid = $('#' + gridName).data("kendoGrid");
        if (grid !== undefined) {
            grid.dataSource.data([]);
        }

        $.ajax({
            url: '/' + this.controllerName + '/List/',
            type: "GET",
            success: function (response) {
                response.data.forEach(element => AddData(JSON.parse(element)));
            }
        });
    }

    createDatePicker(name) {
        $("#" + name).kendoDatePicker();
    }

    createDateTimePicker(name) {
        $("#" + name).kendoDateTimePicker();
    }

    createTabStrip(name) {
        $("#" + name).kendoTabStrip({
            animation: {
                open: {
                    effects: "fadeIn"
                }
            }
        });
    }
}