import { SetStateAction, useState } from 'react';
import './App.css'
import { useNavigate, useParams } from 'react-router'

function App() {
  let a = async (url: string) => {
    let response = await fetch('http://backend:8080/shortener/' + url)
    // .then(response => response.json())
    // .then(data => console.log(data))
    // .catch(error => console.error(error));
    const json = await response.json()
    console.log(json.url);
    return json.url
  };
  const { url } = useParams();
  if (url != null)
  {
    a(url).then(b => {window.location.replace(new URL(b))});
  }
  // a();

  const [inputValue, setInputValue] = useState('');
  const handleInputChange = (event: { target: { value: SetStateAction<string>; }; }) => {
    setInputValue(event.target.value);
  };
  
  let submitURL = async () => {
    let response = await fetch('0.0.0.0:8080/shortener/shortenurl/',
      {
        method: "POST",
        body: JSON.stringify({"url": inputValue})
      }
    );
    console.log(response)
    let navigate = useNavigate();
    navigate("/info/")
  };
  
  return (
    <>
      <div>
        <h1>
          Shortener
        </h1>
        <input 
          type="text" 
          value={inputValue}
          onChange={handleInputChange}
        />
        <button onClick={submitURL}>Shorten</button>
        {/* <img src="data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAApQAAAKUAQAAAACStJWRAAAB40lEQVR4nO3aUW7CMAwA0N5g978lN2ASlDmxQwSknbTp+aMiifPCnxW32/XwuGxMJpPJZDKZTCaTyWQymUwmk8lkMpnM/2BuOb6atPswFqbJTCaTyWSumDGfhjdz2+7JuzlJZjKZTCZz0Wyr2GzrKJnJZDKZzJPMJLV5TCaTyWT+mnkbjHuATCaTyWSeZ46OSKsFSXuZTCaTyVwzU0QpGz1qMpPJZDKZB5hPY99wKdVuHEwmk8lkrpndrtIDfNy+9rzoC6YjmEwmk8lcM7sNMUxwILHAZDKZTOZR5rzL1x6RVic1jslkMpnMd80djrR6tSrlrfvFZDKZTOYhZly3UoMvrlupJVjvYUwmk8lkrpl7Wtfba3Pj2NgRtbBNYTKZTCbzczO4tp492f9BD5DJZDKZzJfNn/l6tXq8iWrNbo7JZDKZzAPMdrFDxr9eqnFMJpPJZL5rjmJ08QqkcEwmk8lkLpuT2vXk6z0mk8lkMs8wu4y5Wf5Fm8xkMplM5qIZGZNHilTtmEwmk8k82mzLW3pjVb+WYDKZTCbzTLPdEGZ3Yr/KZDKZTOaiWY5I59RC184xmUwmk3mAmWJU42pRa5OZTCaTyVw2jwomk8lkMplMJpPJZDKZTCaTyWQymUzm9e+a3yJS1HnqAYMGAAAAAElFTkSuQmCC" alt="Red dot" /> */}
      </div>
    </>
  )
}

export default App
