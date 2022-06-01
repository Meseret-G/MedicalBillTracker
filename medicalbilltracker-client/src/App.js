
import { useState, useEffect } from 'react';
import './styles/index.scss';
import Navbar from './components/Navbar';
import AppRoutes from './routes';
import auth from './Data/auth/apiKey';
import { useNavigate } from 'react-router-dom';
import { patientExistsInDB } from './Data/PatientData';
import SignIn from './views/SignIn';

function App() {
  const [ patient, setPatient] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    
    auth.onAuthStateChanged(async (authed) => {
      if(authed) {
        const patientObj = {
          Name: authed.displayName,
          uid: authed.uid,
          profilePic: authed.photoURL,
          username: authed.email.split('@')[0],
        };
        console.log(patientObj)
        setPatient(patientObj);
        sessionStorage.setItem("token", authed.accessToken);
        patientExistsInDB(authed.accessToken).then(setPatient(patientObj));
      } else {
    
        setPatient(null);
        sessionStorage.removeItem("token");
        navigate('/');
      }
    });
    console.log(patient);
  }, []);

  return (
    <div className="App" >
      <Navbar />  
        <AppRoutes  />
        <SignIn patient={patient} />
      </div>
  
  );
}

export default App;
