var currentId
var currentRow
const tbody = document.querySelector(".tbody")
const noItems = document.querySelector(".noItems")

var deleteModal = new bootstrap.Modal(
    document.querySelector("#delete-modal")
)

if(tbody.children.length === 0){
    noItems.style.display = "block";
}else{
    noItems.style.display = "none";
}

function delItem(id, button){
    currentId = id
    currentRow = button.closest("tr")

    deleteModal.show()
}

document.querySelector("#buttonDelete").addEventListener("click", async () => {
    const response = await fetch(`/Items/DeleteItem?id=${encodeURIComponent(currentId)}`,
        {
            method: "POST",
            headers:
            {
                "RequestVerificationToken": document.querySelector('input[name="__RequestVerificationToken"]').value
            }
        }
    )

    if(response.ok){
        currentRow.remove()
        deleteModal.close()

        if(tbody.children.length === 0){
            noItems.style.display = "block";
        }
    }else{
        alert("unable to delete the item!")
    }
})