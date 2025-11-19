export interface Genre {
  id: number;
  name: string;
}

export interface TrackFormValues {
  title: string;
  description: string;
  audioFile: File | null;
  postImageUrl: string;
  releaseDate: string;
  genreId: string;
}