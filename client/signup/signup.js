const userNameInput = document.querySelector('input[name="userName"]');
const firstNameInput = document.querySelector('input[name="firstName"]');
const lastNameInput = document.querySelector('input[name="lastName"]');
const passwordInput = document.querySelector('input[name="password"]');
const genderSelect = document.querySelector('select[name="gender"]');

const signupForm = document.querySelector('#signup-form');



signupForm.addEventListener('submit', handleSubmit)

function handleSubmit(e) {
    e.preventDefault();
    const userdata = {
        userName: userNameInput.value,
        firstName: firstNameInput.value,
        lastName: lastNameInput.value,
        password: passwordInput.value,
        gender: genderSelect.value,
        avatar: `https://avatars.dicebear.com/api/adventurer/${userNameInput.value}.svg`
    }

    console.log(userdata);
}


function test(num) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (num % 2 == 0) {
                resolve(num)
            }
            else {
                reject('please supply an even number')
            }
        }, 2000);
    })
}

function double(num) {
    console.log('Number',num)
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (num > 10) {
                resolve(num * 2)
            }
            else {
                reject('Number is less than 10')
            }

        }, 2000)
    })
}

// function


// async function functionAsync() {
//     const response = await test();
//     console.log('This is the second invocation')
//     console.log(response)
// }

// functionAsync();

test(20)
    .then(function (res) {
        console.log('Test', res)
       return double(res);
    })
    .then(res =>{
        console.log(res)
    })
    .catch(err => {
        console.error(err)
    })
    .finally(() => {
        console.log('done')
    })

