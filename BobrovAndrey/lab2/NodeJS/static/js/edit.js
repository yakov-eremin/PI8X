$(function () {
    let imageCounter = 1;
    let conditionsCounter = 1;
    addLine("img", imageCounter);
    addLine("conditions", conditionsCounter);
    $("button.navbar-toggler").on("click", function(e) {
        var target = $(this).data("target");
        $(target).toggleClass("show");
    });

    $('.selectElem').change((e) => {
        if(e.target.value == "Другое") {
            e.target.previousElementSibling.classList.remove("hidden");
        }
        else {
            e.target.previousElementSibling.classList.add("hidden");
        }
    })
})

function addLine(classText, counter) {
    $('#add_' + classText).click(() => {
        counter++;
        let blockDom = document.createElement("div");
        blockDom.classList.add("removeBlock");
        blockDom.classList.add("mb-1");
        blockDom.id = classText + counter;
        if(classText == "conditions") {
            blockDom.classList.add("input-group");
        }
        let inputDom = document.createElement("input");
        inputDom.type = "file";
        inputDom.classList.add("custom-file-input");
        if(classText == "conditions") {
            inputDom.classList.add("hidden");
        }
        if(classText == "conditions") {
            inputDom.type = "text";
            inputDom.classList.add("form-control");
            inputDom.placeholder = "текст";
        }
        inputDom.name = `${classText}${counter}`;
        inputDom.id = `${classText}${counter}`;
        let removeDom = document.createElement("div");
        removeDom.classList.add("remove");
        removeDom.innerText = "X";
        removeDom.addEventListener("click", (e)=>{
            e.target.parentNode.remove();
            let images = document.querySelectorAll(`#${classText}List>div`);
            let i = 1;
            images.forEach((elem) => {
                elem.id = classText + i;
                elem.children[0].name = classText + i;
                if(classText == "conditions") {
                    elem.children[0].id = classText + i;
                    elem.children[1].name = classText + i + "Select";
                    elem.children[1].id = classText + i + "Select";
                }
                i++;
            });
        })
        blockDom.appendChild(inputDom);
        if(classText == "conditions") {
            let selectDom = document.createElement("select");
            selectDom.classList.add("form-select");
            selectDom.classList.add("selectElem");
            selectDom.name = `${classText}${counter}Select`;
            selectDom.id = `${classText}${counter}Select`;
            conditions.forEach((elem) => {
                let optionDom = document.createElement("option");
                optionDom.value = elem.name;
                optionDom.innerText = elem.name;
                selectDom.appendChild(optionDom);
            })
            // for(let i = 0; i < 3; i++) {
            //     let optionDom = document.createElement("option");
            //     optionDom.value = "текст";
            //     optionDom.innerText = "текст";
            //     selectDom.appendChild(optionDom);
            // }
            let optionDom = document.createElement("option");
            optionDom.value = "Другое";
            optionDom.innerText = "Другое";
            selectDom.appendChild(optionDom);
            selectDom.addEventListener("change", (e) => {
                if(e.target.value == "Другое") {
                    e.target.previousElementSibling.classList.remove("hidden");
                }
                else {
                    e.target.previousElementSibling.classList.add("hidden");
                }
            })
            blockDom.append(selectDom);
        }
        blockDom.appendChild(removeDom);
        $(`#${classText}List`).append(blockDom);
    });
    $('.remove').click((e) => {
        e.target.parentNode.remove();

        let images = document.querySelectorAll(`#${classText}List>div`);
        let i = 0;
        images.forEach((elem) => {
            elem.name = classText + i;
            i++;
        });
        counter--;
    });
}