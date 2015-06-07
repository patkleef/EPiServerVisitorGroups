
define([
    "dojo",
    "dojo/_base/array",
    "dojo/_base/declare",
    "dojo/json",

    "dijit/registry",
    "dijit/_Widget",
    "dijit/_TemplatedMixin",
    "dijit/_Container",
    "dojox/layout/TableContainer",
    "dijit/form/ValidationTextBox",
    "dojo/text!./templates/CountriesSelectFieldTemplate.html"
],
function (
    dojo,
    array,
    declare,
    json,

    registry,
    _Widget,
    _TemplatedMixin,
    _Container,
    TableContainer,
     ValidationTextBox,
    template
) {
    return declare("app.fields.CountriesSelectField", [
        _Widget,
        _TemplatedMixin,
        _Container], {
            templateString: template,
            chart: null,
            chartOptions: { tooltip: { trigger: 'focus' }, backgroundColor: 'transparent', defaultColor: '#555b64', datalessRegionColor: '#ffffff' },
            chartData: [['Country', '']],
            postCreate: function () {
                this.loadScript();
            },
            _getValueAttr: function () {
                var arr = [];    
                if (this.chartData != null) {
                    array.forEach(this.chartData, function (item, i) {
                        if (i > 0) { // skip the first item in the array
                            arr.push(item[0]);
                        }
                    });
                }
                return json.stringify(arr);
            },
            _setValueAttr: function (val) {
                if (val != null) {
                    var arr = json.parse(val);
                    array.forEach(arr, dojo.hitch(this, function(item, i) {
                        this.chartData.push([ item, item ]);
                    }));
                }
            },

            loadScript: function() {

                var script = document.createElement('script');
                script.type = 'text/javascript';
                script.src = "https://www.google.com/jsapi";
                script.onload = dojo.hitch(this, this.scriptOnLoad);
                document.body.appendChild(script);
            },
            scriptOnLoad: function() {
                if (google) {
                    google.load("visualization", "1", {
                        packages: ["corechart"],
                        callback: dojo.hitch(this, function () {
                            var data = google.visualization.arrayToDataTable(this.chartData);

                            this.chart = new google.visualization.GeoChart(this.container);
                            
                            this.chart.draw(data, this.chartOptions);
                            google.visualization.events.addListener(this.chart, 'regionClick', dojo.hitch(this,this.onRegionSelected));
                        })
                    });
                }
            },
            onRegionSelected: function(e) {
                var region = e.region;

                var index = -1;
                $.each(this.chartData, function (i) {
                    if (this[0] == region) {
                        index = i;
                        return;
                    }
                });
                if (index != -1) {
                    this.chartData.splice(index, 1);

                } else {
                    this.chartData.push([region, region]);
                }
                this.chart.draw(google.visualization.arrayToDataTable(this.chartData), this.chartOptions);
            }
        }
    );
});