"use strict";
var TipoInquilino;
(function (TipoInquilino) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "TipoInquilino/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    TipoInquilino.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(TipoInquilino || (TipoInquilino = {}));
//# sourceMappingURL=Grid.js.map