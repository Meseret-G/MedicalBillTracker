import React , {useState, useEffect }from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { createBill, getBillById, updateBill } from '../Data/BilllData';
//import getPatientbyId from '../Data/PatientData';



const initialState = {
  title: '',
  provider: '',
  imageURL: '',
  outOfPocket : '',
  isArchived: false
  
};

export default function BillForm() {
  const [formInput, setFormInput] = useState({});
  const { dbKey } = useParams();

  //const currentPatient = getPatientbyId

  const navigate = useNavigate();

  useEffect(() => {

    if (dbKey) {
      getBillById(dbKey).then((obj) => {
        setFormInput({
          id: obj?.dbKey,
          title: obj?.title,
          provider: obj?.provider,
          imageURL: obj?.imageURL,
          outOfPocket: obj?.outOfPocket, 
           isArchived: false      
             
        });
      });
    } else {
      setFormInput({
        title: '',
      provider: '',
      imageURL: '',
      outOfPocket : '',
      isArchived: false });
    }
  }, []);

  const handleChange = (e) => {
    //const { name, value } = e.target;
    setFormInput((prevState) => ({
      ...prevState,
      [e.target.name]: e.target.value,
    }));
  };

  const resetForm = () => {   
    setFormInput({ ...initialState });
  };

  const handleSubmit = (e) => {
    e.preventDefault();  
    if (dbKey) {
      updateBill(dbKey, formInput).then(() => {
        resetForm()
        navigate('/');
      }) 
    
    } else 
    {

    
      createBill({...formInput }).then(() => {
        resetForm();
        navigate('/');
      });    

    }
  };

    return (
        
        <>
      <h3>Bill Form</h3>
      <form onSubmit={handleSubmit}>
        <div>
        <label className='form-label' htmlFor="bill">
                Bill Title:
            </label>
          <input
            type='text'
            className='form-control'
            name='title'
            value={formInput.title || ''}
            onChange={handleChange}
            placeholder='Bill Title'
            required
          />
        </div>
        <div>
        <label className='form-label' htmlFor="bill">
               Provider Name:
            </label>
          <input
            type='text'
            className='form-control'
            name='provider'
            value={formInput.provider || ''}
            onChange={handleChange}
            placeholder='Bill Provider'
            required
          />
        </div>
            
        <div>
        <label className='form-label' htmlFor="bill">
                Image:
            </label>
          <input
            type='url'
            className='form-control'
            name='imageURL'
            value={formInput.imageURL || ''}
            onChange={handleChange}
            placeholder='Image'
            
          />
        </div>
        <div>
        <label className='form-label' htmlFor="bill">
                Out of Pocket
            </label>
          <input
            type='number'
            className='form-control'
            name='outOfPocket'
            value={formInput.outOfPocket || ''}
            onChange={handleChange}
            placeholder='Out of Pocket'
            required
          />
         
            
        </div> 
        <button className='addUpdate-button' type='submit'>
          {dbKey ? 'Update' : 'Submit'}
        </button>
      </form>
    </>
  );
}
