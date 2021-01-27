$(document).ready(function () {
    $('#discountInfo').hide();
});

var minDependentLength = 1;
var maxDependentLength = 15;

// Add dependent

$('#btnAddDependent').click(function () {
    if (minDependentLength < maxDependentLength) {
        minDependentLength++;
        $('#dependents').append(`
                       <div class="row">
                               <div class="col-md-3">
                                    <div class="form-group">
                                        <input type="text" name="DependentFirstName[]" class="form-control form-control-sm" oninput="Calculation()">
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <input type="text" name="DependentLastName[]" class="form-control form-control-sm">
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <select class="custom-select custom-select-sm" name="DependentType[]">
                                            <option value="">-Select One-</option>
                                            <option value="1">Children</option>
                                            <option value="2">Spouse</option>
                                        </select>
                                    </div>
                                </div>
                            <div class="col-md-1">
                                <button class="btn btn-sm btn-danger" type="button" id="btnRemoveDependent">-</button>
                            </div>
                        </div>
                        `);
    }
});


// Remove dependent

$('#dependents').on('click', '#btnRemoveDependent', function (e) {
    e.preventDefault();
    $(this).parent().parent().remove();
    Calculation();
    minDependentLength--;
});


function Calculation() {
    let amount = 1000;
    let totalMembers = 1;
    let discountMember = 0;

    let firstName = $('#FirstName').val();

    if (firstName.charAt(0).toUpperCase() === "A") {
        discountMember++;
        amount = amount - amount * 10 / 100;
    }

    $("#dependents .row").each(function (i) {
        totalMembers++;
        var dependFirstName = $(this).find('.form-group:eq(0) input').val();
        if (dependFirstName.length > 0) {
            if (dependFirstName.charAt(0).toUpperCase() === "A") {
                discountMember++;
                amount += 500 - 500 * 10 / 100;
            } else {
                amount += 500;
            }
        }
    });

    $('#perPayCheck').val((amount / 26).toFixed(2));
    $('#yearlyCost').val(amount);
    $('#discountMembers').text(discountMember);
    $('#totalMembers').text(totalMembers);

    if (discountMember > 0) {
        $('#discountInfo').show();
    } else {
        $('#discountInfo').hide();
    }
}