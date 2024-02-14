import { useState } from 'react';
import './App.css';

function App() {
    const [vatResult, setVatResult] = useState<string>("");

    const [countryCode, setCountryCode] = useState<string>("");
    const [vatId, setVatId] = useState<string>("");





    async function PopulateVatVerfication(_event: React.MouseEvent<HTMLButtonElement, MouseEvent>) {
        console.log(countryCode);
        console.log(vatId);
        setCountryCode("");
        setVatId("");
        await populateVatResult()
    }

    return (
        <div>
            <h1 id="countryCode">VAT Verification</h1>
            <label >Country Code: </label>
            <input value={countryCode} name="countryCode" onChange={e => setCountryCode(e.target.value)} />
            <br />
            <label >Vat Id: </label>
            <input value={vatId} name="vatId" onChange={e => setVatId(e.target.value)} />

            <br />
            <button onClick={PopulateVatVerfication}>Check VAT</button>

            <br />
            <h5>{vatResult}</h5>
        </div>
    );

    async function populateVatResult() {
        try {
            console.log(countryCode);
            console.log(vatId);
            const response = await fetch(`https://localhost:7249/VAT/checkvat/${countryCode}/${vatId}`);
            const data = await response.json();
            console.log(data);
            setVatResult(`Country Code: (${countryCode}) -- Vat ID (${vatId}) -- Result (${data.result})`);
        } catch (e) {
            console.log(e);
        }
    }
}

export default App;