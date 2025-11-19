import { useState, useEffect } from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import FormLabel from '@mui/material/FormLabel';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import Stack from '@mui/material/Stack';
import MuiCard from '@mui/material/Card';
import { styled } from '@mui/material/styles';
import MenuItem from '@mui/material/MenuItem';
import Select from '@mui/material/Select';
import Alert from '@mui/material/Alert';
import CircularProgress from '@mui/material/CircularProgress';
import CloudUploadIcon from '@mui/icons-material/CloudUpload';
import { useFormik } from 'formik';
import axios from 'axios';
import type { TrackFormValues } from './types';
import type { Genre } from './types';


const Card = styled(MuiCard)(({ theme }) => ({
  display: 'flex',
  flexDirection: 'column',
  alignSelf: 'center',
  width: '100%',
  padding: theme.spacing(4),
  gap: theme.spacing(2),
  margin: 'auto',
  [theme.breakpoints.up('sm')]: {
    maxWidth: '600px',
  },
  boxShadow:
    'hsla(220, 30%, 5%, 0.05) 0px 5px 15px 0px, hsla(220, 25%, 10%, 0.05) 0px 15px 35px -5px',
  ...theme.applyStyles('dark', {
    boxShadow:
      'hsla(220, 30%, 5%, 0.5) 0px 5px 15px 0px, hsla(220, 25%, 10%, 0.08) 0px 15px 35px -5px',
  }),
}));

const PageContainer = styled(Stack)(({ theme }) => ({
  minHeight: '100vh',
  padding: theme.spacing(2),
  [theme.breakpoints.up('sm')]: {
    padding: theme.spacing(4),
  },
  '&::before': {
    content: '""',
    display: 'block',
    position: 'absolute',
    zIndex: -1,
    inset: 0,
    backgroundImage:
      'radial-gradient(ellipse at 50% 50%, hsl(210, 100%, 97%), hsl(0, 0%, 100%))',
    backgroundRepeat: 'no-repeat',
    ...theme.applyStyles('dark', {
      backgroundImage:
        'radial-gradient(at 50% 50%, hsla(210, 100%, 16%, 0.5), hsl(220, 30%, 5%))',
    }),
  },
}));

const VisuallyHiddenInput = styled('input')({
  clip: 'rect(0 0 0 0)',
  clipPath: 'inset(50%)',
  height: 1,
  overflow: 'hidden',
  position: 'absolute',
  bottom: 0,
  left: 0,
  whiteSpace: 'nowrap',
  width: 1,
});



const AddTrackPage = () => {
  const [genres, setGenres] = useState<Genre[]>([]);
  const [loading, setLoading] = useState(false);
  const [loadingGenres, setLoadingGenres] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [success, setSuccess] = useState(false);
  const [fileName, setFileName] = useState<string>('');

  useEffect(() => {
    fetchGenres();
  }, []);

  const fetchGenres = async () => {
    try {
      const token = localStorage.getItem('token');
      const response = await axios.get('https://localhost:5001/api/Genre', {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      setGenres(response.data.payload || response.data);
    } catch (err: any) {
      setError('Error fetching genres');
      console.error('Error fetching genres:', err);
    } finally {
      setLoadingGenres(false);
    }
  };

  const handleSubmit = async (values: TrackFormValues) => {
    if (!values.audioFile) {
      setError('Please select an audio file');
      return;
    }

    try {
      setLoading(true);
      setError(null);
      setSuccess(false);

      const formData = new FormData();
      formData.append('Title', values.title);
      formData.append('Description', values.description);
      formData.append('AudioFile', values.audioFile);
      formData.append('PostImageUrl', values.postImageUrl);
      formData.append('ReleaseDate', values.releaseDate);
      formData.append('GenreId', values.genreId);

      const token = localStorage.getItem('token');

      await axios.post('https://localhost:5001/api/dev/Track', formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
          Authorization: `Bearer ${token}`,
        },
      });

      setSuccess(true);
      formik.resetForm();
      setFileName('');
      
      setTimeout(() => {
        setSuccess(false);
      }, 5000);
    } catch (err: any) {
      setError(err.response?.data?.message || 'Error adding track');
      console.error('Error adding track:', err);
    } finally {
      setLoading(false);
    }
  };

  const formik = useFormik<TrackFormValues>({
    initialValues: {
      title: '',
      description: '',
      genreId: '',
      postImageUrl: '',
      releaseDate: new Date().toISOString().split('T')[0],
      audioFile: null,
    },
    onSubmit: handleSubmit,
  });

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      formik.setFieldValue('audioFile', file);
      setFileName(file.name);
    }
  };

  return (
    <>
      <CssBaseline enableColorScheme />
      <PageContainer direction="column" justifyContent="center">
        <Card variant="outlined">
          <Typography
            component="h1"
            variant="h4"
            sx={{ width: '100%', fontSize: 'clamp(2rem, 10vw, 2.15rem)' }}
          >
            Add Track
          </Typography>

          {success && (
            <Alert severity="success">Track added successfully!</Alert>
          )}

          {error && (
            <Alert severity="error" onClose={() => setError(null)}>
              {error}
            </Alert>
          )}

          <Box
            component="form"
            onSubmit={formik.handleSubmit}
            noValidate
            sx={{
              display: 'flex',
              flexDirection: 'column',
              width: '100%',
              gap: 2,
            }}
          >
            <FormControl>
              <FormLabel htmlFor="title">Nazva treku *</FormLabel>
              <TextField
                id="title"
                name="title"
                placeholder="Enter title"
                required
                fullWidth
                variant="outlined"
                onChange={formik.handleChange}
                value={formik.values.title}
              />
            </FormControl>

            <FormControl>
              <FormLabel htmlFor="description">description *</FormLabel>
              <TextField
                id="description"
                name="description"
                placeholder="Enter description"
                required
                fullWidth
                multiline
                rows={3}
                variant="outlined"
                onChange={formik.handleChange}
                value={formik.values.description}
              />
            </FormControl>

            <FormControl>
              <FormLabel htmlFor="postImageUrl">URL poster *</FormLabel>
              <TextField
                id="postImageUrl"
                name="postImageUrl"
                placeholder="https://example.com/image.jpg"
                required
                fullWidth
                variant="outlined"
                onChange={formik.handleChange}
                value={formik.values.postImageUrl}
              />
            </FormControl>

            <FormControl>
              <FormLabel htmlFor="releaseDate">Release date*</FormLabel>
              <TextField
                id="releaseDate"
                name="releaseDate"
                type="date"
                required
                fullWidth
                variant="outlined"
                onChange={formik.handleChange}
                value={formik.values.releaseDate}
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </FormControl>

            <FormControl>
              <FormLabel htmlFor="genreId">Genre *</FormLabel>
              <Select
                id="genreId"
                name="genreId"
                value={formik.values.genreId}
                onChange={formik.handleChange}
                required
                fullWidth
                disabled={loadingGenres}
                displayEmpty
              >
                <MenuItem value="" disabled>
                  Choose a genre
                </MenuItem>
                {genres.map((genre) => (
                  <MenuItem key={genre.id} value={genre.id.toString()}>
                    {genre.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>

            <FormControl>
              <FormLabel>audiofile *</FormLabel>
              <Button
                component="label"
                variant="outlined"
                startIcon={<CloudUploadIcon />}
                sx={{ mt: 1 }}
              >
                Load file
                <VisuallyHiddenInput
                  type="file"
                  accept="audio/*"
                  onChange={handleFileChange}
                />
              </Button>
              {fileName && (
                <Typography variant="body2" sx={{ mt: 1, color: 'text.secondary' }}>
                  File: {fileName}
                </Typography>
              )}
            </FormControl>

            <Button
              type="submit"
              fullWidth
              variant="contained"
              disabled={loading}
              sx={{ mt: 2 }}
            >
              {loading ? <CircularProgress size={24} /> : 'add track'}
            </Button>
          </Box>
        </Card>
      </PageContainer>
    </>
  );
};

export default AddTrackPage;