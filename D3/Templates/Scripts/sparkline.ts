interface IBounds {
    domain(upperAndLowerBound: number[]): IBounds;
    range(upperAndLowerBound: number[]): IBounds;
}

interface IScale {
    linear(): IBounds;
    
}

interface IGraphingUtility {

    select(id: string): IGraphingUtility;
    append(htmlNode: string): IGraphingUtility;
    attr(attribute: string, value: string): IGraphingUtility; 

}


function openGraphUtility(grapher: IGraphingUtility) {

    function getGraph(wrapper: string) {
        grapher.select(wrapper).append("svg:svg").append("width:100%").append("width:100%");
    }
}

