import { useParams } from 'react-router';

function Info(){
    let urldata;
    let a = async (url: string) => {
        let response = await fetch('http://backend:8080/shortener/geturl/' + url)
        .then(response => response.json())
        .then(data => {return data})
        .catch(error => console.error(error));
        // const json = await response.json()
        // console.log(json.url);
        // return json.url
        // console.log(response);
        urldata = response
        };
    const { url } = useParams();


    if (url != null)
    {
        a(url);
        console.log(urldata);
    }

    return(
        <>
            <h1>INFO</h1>
            <h2>ORIGINAL URL</h2>
            {/* <p>{urldata.originalURL}</p> */}
        </>
    )
}

export default Info