import { useState, useEffect } from 'react';

const Home = () => {
    const [adoption, setAdoption] = useState();

    useEffect(() => {
        populateAdoptionData();
    }, []);

    const contents = adoption === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Pet Name</th>
                    <th>Pet Description</th>
                    <th>Pet Breed</th>
                    <th>Pet PhotoFileName</th>
                    <th>Pet Age</th>
                </tr>
            </thead>
            <tbody>
                {adoption.map(adoption =>
                    <tr key={adoption.Id}>
                        <td>{adoption.petName}</td>
                        <td>{adoption.petDescription}</td>
                        <td>{adoption.petBreed}</td>
                        <td>{adoption.petPhotoFileName}</td>
                        <td>{adoption.petAge}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (

        <div>
            <h1 id="tabelLabel">Pet adoption</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

            async function populateAdoptionData() {
            const response = await fetch('adoption');
            const data = await response.json();
            setAdoption(data);
            }
};

export default Home;