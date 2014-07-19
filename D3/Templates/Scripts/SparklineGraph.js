function openSparkGraphUtility(grapher) {
    return function (wrapper) {
        var g = grapher.select("#" + wrapper).append("svg:svg").attr("width", "100%").attr("height", "100%");
        var x = grapher.scale.linear().domain([0, 50]).range([0, 100]);
        var y = grapher.scale.linear().domain([0, 50]).range([0, 100]);

        var svg = d3.svg.line().x(function (d, i) {
            return x(i);
        }).y(function (d, i) {
            return y(d);
        });

        return function (data) {
            g.append("svg:path").attr("d", svg(data));
        };
    };
}
//# sourceMappingURL=SparklineGraph.js.map
