
import React from 'react';
import './styles/index.scss';
import Navbar from './components/Navbar';
import AppRoutes from './routes';
// import auth from './Data/auth/firebaseConfig';
// import { useNavigate } from 'react-router-dom';
// import SignIn from './views/SignIn';


function App() {
 // const [ user, setUser] = useState(null);
  // navigate = useNavigate();

  // useEffect(() => {
    
  //   auth.onAuthStateChanged(async (authed) => {
  //     if(authed) {
  //       const userObj = {
  //         Name: authed.displayName,
  //         uid: authed.uid,
  //         profilePic: authed.photoURL,
  //         username: authed.email.split('@')[0],
  //       };
       
  //       console.log(userObj);
  //       setUser(userObj);
        
  //     } else if (user || user === null){
  //      setUser(false);
  //       navigate('/');
  //     }
  //   });
    
  // }, []);

  return (
  

     <div className="app">
         <Navbar  />  
<div className="main-container">
        <AppRoutes />

        </div>
  </div>  
  
  );
}

export default App;
