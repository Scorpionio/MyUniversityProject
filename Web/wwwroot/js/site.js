const typeSelector = document.getElementById("typeSelector");
const processorFields = document.getElementById("processorFields");
const graphicCardFields = document.getElementById("graphicCardFields");

typeSelector.addEventListener("change", function () {
    const type = typeSelector.value;

    if (type === "Processor") {
        processorFields.classList.remove("hidden");
        graphicCardFields.classList.add("hidden");
    } else if (type === "GraphicCard") {
        graphicCardFields.classList.remove("hidden");
        processorFields.classList.add("hidden");
    }
});